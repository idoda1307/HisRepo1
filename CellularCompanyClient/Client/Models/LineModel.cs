using Client.CRMServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class LineModel : INotifyPropertyChanged
    {
        private string _number;
        private ClientModel _client;
        private PackageModel _package;

        public int LineId { get; set; }

        public string Number
        {
            get { return _number; }
            set { _number = value; Notify(nameof(Number)); }
        }
        public LineStatus Status { get; set; }

        public string ClientId { get; set; }
        public ClientModel Client
        {
            get { return _client; }
            set { _client = value; Notify(nameof(Client)); }
        }

        public int PackageId { get; set; }
        public PackageModel Package
        {
            get { return _package; }
            set { _package = value; Notify(nameof(Package)); }
        }

        public int SelectedNumberId { get; set; }
        public SelectedNumbersModel SelectedNumber { get; set; }

        public IEnumerable<CommunicationModel> SMS { get; set; }
        public IEnumerable<CommunicationModel> Calls { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}