using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class PackageDto
    {
        [DataMember]
        public int PackageId { get; set; }
        [DataMember]
        public string PackageName { get; set; }
        [DataMember]
        public double PackageTotalPrice { get; set; }

        public IEnumerable<LineDto> Lines { get; set; }
        [DataMember]
        public PackageIncludesDto PackageIncludes { get; set; }
    }
}
