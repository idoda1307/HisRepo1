using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PackageEntity
    {
        public PackageEntity()
        {
            Lines = new HashSet<LineEntity>();
        }
        [Key]
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public double PackageTotalPrice { get; set; }

        public PackageIncludesEntity PackageIncludes { get; set; }

        public ICollection<LineEntity> Lines { get; set; }
    }
}