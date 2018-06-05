using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ClientEntity
    {
        public ClientEntity()
        {
            Payments = new HashSet<PaymentEntity>();
            Lines = new HashSet<LineEntity>();
        }

        [Key]
        public string ClientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public int? CallsToCenter { get; set; }
        
        [ForeignKey(nameof(ClientType))]
        public int ClientTypeId { get; set; }
        public ClientTypeEntity ClientType { get; set; }

        public virtual ICollection<PaymentEntity> Payments { get; set; }
        public virtual ICollection<LineEntity> Lines { get; set; }
    }
}
