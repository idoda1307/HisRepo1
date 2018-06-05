using Client.Infrastructure;
using Client.Models;
using Client.ObservableCollections;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class OptimalPackageViewModel:ViewModelBase
    {
        //properties
        public LineModel Line { get; set; }
        //observable collections
        public ObservableCollection<ClientModel> Clients { get; set; }
        public CustomObservableCollection<LineModel> Lines { get; set; }
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
        //ctor
        public OptimalPackageViewModel(ILineService lineService,INavigationService navigationService)
        {
            _lineService = lineService;
            _navigationService = navigationService;
            Client = new ClientModel();
            Line = new LineModel();
            Clients = new ObservableCollection<ClientModel>();
            Lines = new CustomObservableCollection<LineModel>();


            var clientsTask = Task.Factory.StartNew(() => _lineService.GetClients());
            Clients = new ObservableCollection<ClientModel>(clientsTask.Result.Result);
            RaisePropertyChanged(nameof(Clients));
        }
    }
}
