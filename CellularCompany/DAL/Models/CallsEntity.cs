﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CallsEntity
    {
        [Key]
        public int CallId { get; set; }
        public double Duration { get; set; }
        public double ExternalPrice { get; set; }
        public string DestinationNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [ForeignKey(nameof(Line))]
        public int LineId { get; set; }
        public LineEntity Line { get; set; }
    }
}
