using Client.CRMServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class PackageModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public double PackageTotalPrice { get; set; }

        public PackageIncludesModel PackageIncludes { get; set; }
        public IEnumerable<LineModel> Lines { get; set; }
    }
}