using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;
using Client.Infrastructure;
using Windows.UI.Popups;
using Client.Models;

namespace Client.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        //commands
        public ICommand SaveClientCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand CleanClientCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        //members
        private readonly INavigationService _navigationService;
        private readonly IClientService _clientService;
        //properties
        public string ClientID { get; set; }
        public ClientModel ClientInfo { get; set; }
        public int ClientTypeId { get; set; }
        //observable collections
        public ObservableCollection<ClientTypeModel> Types { get; set; }
        public ObservableCollection<string> ClientsIds { get; set; }
        //ctor
        public ClientViewModel(INavigationService navigationService, IClientService service)
        {
            _clientService = service;
            _navigationService = navigationService;

            ClientInfo = new ClientModel();

            InitializeObservableCollections();
            InitializeCommands();
        }
        //methods
        private void InitializeObservableCollections()
        {
            var typesTask = Task.Factory.StartNew(() => _clientService.GetClientTypes());
            Types = new ObservableCollection<ClientTypeModel>(typesTask.Result.Result);
            RaisePropertyChanged(nameof(Types));

            var clientsTask = Task.Factory.StartNew(() => _clientService.GetClientsIds());
            ClientsIds = new ObservableCollection<string>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(ClientsIds));
        }

        public void InitializeCommands()
        {
            SaveClientCommand = new RelayCommand(() =>
            {
                try
                {
                    if (ClientID == null)
                        _clientService.AddClient(ClientInfo);
                    else
                        _clientService.UpdateClient(ClientID, ClientInfo);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
            DeleteClientCommand = new RelayCommand(() =>
            {
                _clientService.RemoveClient(ClientID);
                RaisePropertyChanged(nameof(ClientsIds));
            });
            CleanClientCommand = new RelayCommand(() =>
            {
                ClientInfo = null;
                RaisePropertyChanged(nameof(ClientInfo));

            });
            GoBackCommand = new RelayCommand(() =>
            {
                _navigationService.GoBack();
            });
        }
    }
}