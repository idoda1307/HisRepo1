using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PaymentEntity
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public double TotalPayment { get; set; }
        
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
}
