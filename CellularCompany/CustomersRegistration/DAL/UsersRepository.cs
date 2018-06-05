using CustomersRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomersRegistration.DAL
{
    public class UsersRepository
    {
        public UserDto FindUser(string id,string contactNumber)
        {
            using (var db = new UsersContext())
            {
                foreach (var item in db.Users)
                {
                    if(item.ContactNumber==contactNumber && id==item.Id)
                    {
                        return item.ToDto();
                    }
                }
                return null;
            }
        }
    }
}