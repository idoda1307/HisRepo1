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
    public class OptimalPackageViewModel : ViewModelBase
    {
        //properties
        public LineModel Line { get; set; }
        public double TotalMinutes { get; set; }
        public int TotalSmss { get; set; }
        public double TotalMinutesTopNumber { get; set; }
        public double TotalMinutes3TopNumbers { get; set; }
        public double TotalMinutesWithFamily { get; set; }
        public double ClientValue { get; set; }
        //observable collections
        public ObservableCollection<ClientModel> Clients { get; set; }
        public CustomObservableCollection<LineModel> Lines { get; set; }
        //commands
        public ICommand CalculateOptimalPackage { get; set; }
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
        //members
        private readonly ILineService _lineService;
        private readonly INavigationService _navigationService;
        private readonly IOptimalPackageService _optimalPackageService;
        //ctor
        public OptimalPackageViewModel(ILineService lineService, INavigationService navigationService, IOptimalPackageService optimalPackage)
        {
            _optimalPackageService = optimalPackage;
            _lineService = lineService;
            _navigationService = navigationService;
            Client = new ClientModel();
            Line = new LineModel();
            Clients = new ObservableCollection<ClientModel>();
            Lines = new CustomObservableCollection<LineModel>();


            var clientsTask = Task.Factory.StartNew(() => _lineService.GetClients());
            Clients = new ObservableCollection<ClientModel>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(Clients));

            CalculateOptimalPackage = new RelayCommand(() =>
              {
                  Calculations();
              });
        }

        private void Calculations()
        {
            try
            {
                var totalMinutes = Task.Factory.StartNew(() => _optimalPackageService.CalaculateTotalMinutes(Line.LineId));
                TotalMinutes = totalMinutes.Result.Result;

                var totalSms = Task.Factory.StartNew(() => _optimalPackageService.CalculateTotalSMS(Line.LineId));
                TotalSmss = totalSms.Result.Result;

                var totalMinutesTopNumber = Task.Factory.StartNew(() => _optimalPackageService.CalculateTotalMinutesOfTopNumber(Line.LineId));
                TotalMinutesTopNumber = totalMinutesTopNumber.Result.Result;

                var totalMinutesTop3Numbers = Task.Factory.StartNew(() => _optimalPackageService.CalculateTotalMinutesOf3TopNumbers(Line.LineId));
                TotalMinutes3TopNumbers = totalMinutesTop3Numbers.Result.Result;

                var totalMinutesWithFamily = Task.Factory.StartNew(() => _optimalPackageService.CalculateTotalMinutesWithFamily(Line.LineId));
                TotalMinutesWithFamily = totalMinutesWithFamily.Result.Result;

                var clientValue = Task.Factory.StartNew(() => _optimalPackageService.CalculateClientValue(Client.ClientId));
                ClientValue = clientValue.Result.Result;

                RaisePropertyChanged(nameof(ClientValue));
                RaisePropertyChanged(nameof(TotalMinutes));
                RaisePropertyChanged(nameof(TotalSmss));
                RaisePropertyChanged(nameof(TotalMinutes3TopNumbers));
                RaisePropertyChanged(nameof(TotalMinutesTopNumber));
                RaisePropertyChanged(nameof(TotalMinutesWithFamily));
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
