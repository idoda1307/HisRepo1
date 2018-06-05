using Client.Infrastructure;
using Client.InvoiceServiceReference;
using Client.Models;
using Client.ObservableCollections;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class SimulatorViewModel : ViewModelBase
    {
        //observable collections
        public ObservableCollection<ClientModel> Clients { get; set; }
        public CustomObservableCollection<LineModel> Lines { get; set; }
        public CustomObservableCollection<LineModel> DestinationNumbers { get; set; }
        //commands
        public ICommand GoBackCommand { get; set; }
        public ICommand CreateCommunication { get; set; }
        //private fields
        private ClientModel _client;
        private LineModel _line;
        private bool _smsIsChecked=true;
        //properties
        public LineModel DestinationLine { get; set; }
        public CommunicationModel Communication { get; set; }
        public double Duration { get; set; }
        public bool DestinationEnabled { get; set; }

        //full properties
        public bool SMSIsChecked
        {
            get { return _smsIsChecked; }
            set
            {
                if (_smsIsChecked == value) return;
                _smsIsChecked = value;
                DestinationEnabled = _smsIsChecked ? false : true;
                RaisePropertyChanged(nameof(_smsIsChecked));
                RaisePropertyChanged(nameof(DestinationEnabled));
            }
        }

        public ClientModel Client
        {
            get { return _client; }
            set
            {
                try
                {
                    _client = value;
                    Task.Factory.StartNew(() =>
                    {
                        var linesTask = _lineService.GetLines(Client.ClientId).Result;
                        this.Lines.Repopulate(linesTask);
                        //RaisePropertyChanged(nameof(Lines));
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public LineModel Line
        {
            get { return _line; }
            set
            {
                _line = value;
                Task.Factory.StartNew(() =>
                {
                    var destinationNUmbersTask = _simulatorService.GetDestinationLines(Line.LineId).Result;
                    this.DestinationNumbers.Repopulate(destinationNUmbersTask);
                });
            }
        }

        //members
        private readonly ISimulatorService _simulatorService;
        private readonly ILineService _lineService;
        private readonly INavigationService _navigationService;
        //ctor
        public SimulatorViewModel(INavigationService navigationService, ILineService lineService, ISimulatorService simulatorService)
        {

            _simulatorService = simulatorService;
            _lineService = lineService;
            _navigationService = navigationService;
            Communication = new CommunicationModel();
            Client = new ClientModel();
            Line = new LineModel();
            DestinationLine = new LineModel();

            InitializeObservableCollections();
            InitializeCommands();
        }
        //methods
        private void InitializeCommands()
        {
            GoBackCommand = new RelayCommand(() =>
            {
                _navigationService.GoBack();
            });
            CreateCommunication = new RelayCommand(() =>
              {
                  Communication.DestinationNumber = DestinationLine.Number;
                  Communication.Line = Line;
                  _simulatorService.CreateCommunication(Communication, SMSIsChecked, Duration);
              });
        }

        private void InitializeObservableCollections()
        {
            Lines = new CustomObservableCollection<LineModel>();
            DestinationNumbers = new CustomObservableCollection<LineModel>();

            var clientsTask = Task.Factory.StartNew(() => _lineService.GetClients());
            Clients = new ObservableCollection<ClientModel>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(Clients));
        }
    }
}