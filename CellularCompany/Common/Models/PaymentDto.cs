using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class PaymentDto
    {
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public double TotalPayment { get; set; }

        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public ClientDto Client { get; set; }
    }
}
