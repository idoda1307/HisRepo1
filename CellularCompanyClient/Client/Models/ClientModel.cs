using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class ClientModel:INotifyPropertyChanged
    {
        private string _clientId;
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; Notify(nameof(ClientId)); }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int CallsToCenter { get; set; }
        
        public int ClientTypeId { get; set; }
        public ClientTypeModel ClientType { get; set; }

        public IEnumerable<PaymentModel> Payments { get; set; }
        public IEnumerable<LineModel> Lines { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
