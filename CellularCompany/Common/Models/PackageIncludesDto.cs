using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class PackageIncludesDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IncludeName { get; set; }
        [DataMember]
        public int MaxMinute { get; set; }
        [DataMember]
        public double FixedPrice { get; set; }
        [DataMember]
        public double DiscountPrecentage { get; set; }
        [DataMember]
        public bool MostCalledNumber { get; set; }
        [DataMember]
        public bool InsideFamilyCalls { get; set; }

        [DataMember]
        public int PackageId { get; set; }
        [DataMember]
        public PackageDto Package { get; set; }

    }
}
