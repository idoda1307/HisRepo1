using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class InvoiceModel
    {
        public ClientModel Client { get; set; }
        public LineModel Line { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
