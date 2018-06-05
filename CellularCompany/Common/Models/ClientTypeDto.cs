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
    public class ClientTypeDto
    {
        [DataMember]
        public int ClientTypeId { get; set; }
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public double MinutePrice { get; set; }
        [DataMember]
        public double SMSPrice { get; set; }

        public IEnumerable<ClientDto> Clients { get; set; }
    }
}
