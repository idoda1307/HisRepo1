using Client.CRMServiceReference;
using Client.Infrastructure;
using Client.Models;
using Client.ReportsEngineServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ManagerService:IManagerService
    {
        ReportsEngineServiceClient _service=new ReportsEngineServiceClient();
        public async Task<IEnumerable<string>> GetMostValuableClients()
        {
            try
            {
                return await _service.MostValuableClientsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<string>> GetMostCallingToCenter()
        {
            return await _service.MostCallingToCenterClientsAsync();
        }

        //public async Task<StringBuilder> GetGroups()
        //{
        //    return await _service.GetGroupsAsync();
        //}
    }
}
