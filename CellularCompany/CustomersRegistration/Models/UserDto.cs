using CustomersRegistration.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersRegistration.Models
{
    [UserLoginValidator(ErrorMessage = "The id or contact number you’ve entered doesn’t exist.")]
    public class UserDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "your contact number is too short/long", MinimumLength = 3)]
        public string ContactNumber { get; set; }
    }
}