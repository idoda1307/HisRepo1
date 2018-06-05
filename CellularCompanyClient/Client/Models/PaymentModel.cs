using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public double TotalPayment { get; set; }
        
        public string ClientId { get; set; }
        public ClientModel Client { get; set; }
    }
}
