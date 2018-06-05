using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Models.ClientTypeEntity;
using Common.Interfaces;
using Common.Models;
using Dtos;
using System.Diagnostics;
using Common.Interfaces.RepositoryInterfaces;
using System.Data.Entity.Migrations;

namespace DAL.Repositories
{
    public class ClientTypeRepository : IClientTypeRepository
    {
        
        public ClientTypeDto GetClientType(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.ClientType.FirstOrDefault(c => c.ClientTypeId == id).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<ClientTypeDto> GetClientTypes()
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var a= db.ClientType.ToList();
                  return  a.Select(c => c.ToDto()).ToList();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}