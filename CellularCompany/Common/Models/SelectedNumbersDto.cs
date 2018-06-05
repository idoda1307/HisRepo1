using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class SelectedNumbersDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstNumber { get; set; }
        [DataMember]
        public string SecondNumber { get; set; }
        [DataMember]
        public string ThirdNumber { get; set; }
        [DataMember]
        public LineDto Line { get; set; }
        [DataMember]
        public int LineId { get; set; }
    }
}