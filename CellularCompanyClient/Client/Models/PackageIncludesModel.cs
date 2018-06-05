using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class PackageIncludesModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string IncludeName { get; set; }
        
        public int MaxMinute { get; set; }
        public double FixedPrice { get; set; }
        public double DiscountPrecentage { get; set; }
        public bool MostCalledNumber { get; set; }
        public bool InsideFamilyCalls { get; set; }
        
        public PackageModel Package { get; set; }
        public int PackageId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
