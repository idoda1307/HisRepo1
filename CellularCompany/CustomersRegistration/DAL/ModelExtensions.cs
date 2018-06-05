using CustomersRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomersRegistration.DAL
{
    public static class ModelExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto()
            {
                ContactNumber=user.ContactNumber,
                Id=user.Id
            };
        }

        public static User ToModel(this UserDto user)
        {
            return new User()
            {
                ContactNumber=user.ContactNumber,
                Id=user.Id
            };
        }
    }
}