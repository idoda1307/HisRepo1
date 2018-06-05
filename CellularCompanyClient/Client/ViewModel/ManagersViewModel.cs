using Client.Infrastructure;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class ManagersViewModel : ViewModelBase
    {
        private readonly IManagerService _managerService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<string> Clients { get; set; }
        public ObservableCollection<string> CallsToCenter { get; set; }

        public ICommand GoBackCommand { get; set; }

        public string Sb { get; set; }

        public ManagersViewModel(INavigationService navigationService, IManagerService managerService)
        {
            _navigationService = navigationService;
            _managerService = managerService;

            var getClients = Task.Factory.StartNew(() => _managerService.GetMostValuableClients());
            Clients = new ObservableCollection<string>(getClients.Result.Result);

            var calls = Task.Factory.StartNew(() => _managerService.GetMostCallingToCenter());
            CallsToCenter = new ObservableCollection<string>(calls.Result.Result);
            GoBackCommand = new RelayCommand(() => _navigationService.GoBack());
            //Sb = _managerService.GetGroups().Result.ToString();
        }
    }
}
