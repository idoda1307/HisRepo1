using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class LineDto
    {
        [DataMember]
        public int LineId { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public LineStatus Status { get; set; }

        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public ClientDto Client { get; set; }
        
        [DataMember]
        public PackageDto Package { get; set; }
        [DataMember]
        public int PackageId { get; set; }

        [DataMember]
        public SelectedNumbersDto SelectedNumber { get; set; }
        [DataMember]
        public int SelectedNumberId { get; set; }

        public IEnumerable<SMSDto> SMS { get; set; }
        public IEnumerable<CallsDto> Calls { get; set; }
    }
}
