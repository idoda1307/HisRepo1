using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class SMSDto
    {
        [DataMember]
        public int SMSId { get; set; }
        [DataMember]
        public double ExternalPrice { get; set; }
        [DataMember]
        public string DestinationNumber { get; set; }
        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public int LineId { get; set; }
        [DataMember]
        public LineDto Line { get; set; }
    }
}
