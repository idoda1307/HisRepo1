using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class ClientDto
    {
        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
        [DataMember]
        public int? CallsToCenter { get; set; }

        [DataMember]
        public int ClientTypeId { get; set; }
        [DataMember]
        public ClientTypeDto ClientType { get; set; }

        public IEnumerable<PaymentDto> Payments { get; set; }
        public IEnumerable<LineDto> Lines { get; set; }
    }
}