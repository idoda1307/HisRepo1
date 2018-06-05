namespace CustomersRegistration.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [StringLength(10)]
        public string Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNumber { get; set; }
    }
}
