using CustomersRegistration.DAL;
using CustomersRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersRegistration.Validators
{
    public class UserLoginValidator:ValidationAttribute
    {
        public override bool IsValid(object user)
        {
            if (user != null)
            {
                UserDto use = (UserDto)user;
                UsersRepository users = new UsersRepository();
                if (users.FindUser(use.Id, use.ContactNumber) != null)
                    return true;
                return false;
            }
            return false;
        }
    }
}