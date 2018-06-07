using Client.DataShare;
using Client.Infrastructure;
using Client.Models;
using Client.ObservableCollections;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
    public class PaymentCalculationViewModel : ViewModelBase
    {
        //observable collections
        public ObservableCollection<ClientModel> Clients { get; set; }
        public CustomObservableCollection<LineModel> Lines { get; set; }
        //commands
        public ICommand GoBackCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        //private fields
        private InvoiceModel _invoice;
        private ClientModel _client;
        //full properties
        public ClientModel Client
        {
            get { return _client; }
            set
            {
                _client = value;
                Task.Factory.StartNew(() =>
                {
                    var linesTask = _lineService.GetLines(Client.ClientId).Result;
                    this.Lines.Repopulate(linesTask);
                    //RaisePropertyChanged(nameof(Lines));
                });
            }
        }

        public InvoiceModel Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                RaisePropertyChanged(nameof(_invoice));
            }
        }
        //members
        private readonly ILineService _lineService;
        private readonly INavigationService _navigationService;
        //ctor
        public PaymentCalculationViewModel(INavigationService navigationService, ILineService lineService)
        {
            _navigationService = navigationService;
            _lineService = lineService;
            Invoice = new InvoiceModel();
            Client = new ClientModel();
            Lines = new CustomObservableCollection<LineModel>();
            InitializeObservableCollections();
            InitializeMethods();
        }

        //methods
        private void InitializeObservableCollections()
        {
            var clientsTask = Task.Factory.StartNew(() => _lineService.GetClients());
            Clients = new ObservableCollection<ClientModel>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(Clients));
        }

        private void InitializeMethods()
        {
            GoBackCommand = new RelayCommand(() =>_navigationService.GoBack());
            CalculateCommand = new RelayCommand(() =>
              {
                  try
                  {
                      var invoice = new InvoiceModel() { Date = Invoice.Date, Client = Client, Line = Invoice.Line };
                      TransformModel.Invoice = invoice;
                      _navigationService.NavigateTo("PaymentView");
                  }
                  catch(Exception ex)
                  {
                      Debug.WriteLine(ex.Message);
                  }
              });
        }
    }
}