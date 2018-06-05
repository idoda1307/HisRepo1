using Client.Infrastructure;
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
    public class LinesViewModel : ViewModelBase
    {
        //models properties
        public LineModel Line { get; set; }
        public LineModel SelectedLine { get; set; }
        //public PackageModel Package { get; set; }
        public SelectedNumbersModel SelectedNumbers { get; set; }
        //observable collections
        public CustomObservableCollection<LineModel> Lines { get; set; }
        public ObservableCollection<ClientModel> Clients { get; set; }
        public ObservableCollection<PackageModel> Packages { get; set; }
        //commands
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        //private fields
        private ClientModel _client;
        //full properties
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
                        var list = _lineService.GetLines(Client.ClientId).Result;
                        if (list != null)
                            this.Lines.Repopulate(list);
                        else Lines = null;
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        //members
        private readonly INavigationService _navigationService;
        private readonly ILineService _lineService;
        //ctor
        public LinesViewModel(INavigationService navigationService, ILineService lineService)
        {
            try
            {
                _lineService = lineService;
                _navigationService = navigationService;
                SelectedLine = new LineModel();
                Line = new LineModel();
                SelectedNumbers = new SelectedNumbersModel();
                Lines = new CustomObservableCollection<LineModel>();
                InitializeObservableCollections();
                InitializeCommands();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //methods
        private void InitializeObservableCollections()
        {
            var clientsTask = Task.Factory.StartNew(() => _lineService.GetClients());
            Clients = new ObservableCollection<ClientModel>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(Clients));

            var packagesTask = Task.Factory.StartNew(() => _lineService.GetPackages());
            Packages = new ObservableCollection<PackageModel>(packagesTask.Result.Result);
            RaisePropertyChanged(nameof(Packages));
        }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(() =>
            {
                Line.Client = Client;
                Line.ClientId = Client.ClientId;
                Line.Status = CRMServiceReference.LineStatus.available;
                if (SelectedLine.LineId == 0)
                    _lineService.AddLine(Line, SelectedNumbers);
                else
                    _lineService.UpdateLine(SelectedLine.LineId, Line,SelectedNumbers);
            });
            ClearCommand = new RelayCommand(() =>
            {
                Line = null;
                SelectedNumbers = null;
                SelectedLine = null;
                RaisePropertyChanged(nameof(Line));
                RaisePropertyChanged(nameof(SelectedNumbers));
                RaisePropertyChanged(nameof(SelectedLine));
            });
            DeleteCommand = new RelayCommand(() =>
              {
                  _lineService.DeleteLine(SelectedLine);
              });
            GoBackCommand = new RelayCommand(() =>
            {
                _navigationService.GoBack();
            });
        }
    }
}