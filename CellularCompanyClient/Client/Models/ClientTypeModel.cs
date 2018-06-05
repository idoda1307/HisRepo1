using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class ClientTypeModel:INotifyPropertyChanged
    {
        public int ClientTypeId { get; set; }
        private string _typeName;
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; Notify(nameof(TypeName)); }
        }
        public double MinutePrice { get; set; }
        public double SMSPrice { get; set; }
        public IEnumerable<ClientModel> Clients { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
