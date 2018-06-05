using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.ServicesInterfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportsEngineService : IReportsEngineService
    {
        private readonly IReportsEngineManager _reportsEngineManager;
        public ReportsEngineService(IReportsEngineManager reportsEngineManager)
        {
            _reportsEngineManager = reportsEngineManager;
        }

        public async Task<IEnumerable<string>> MostValuableClients()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _reportsEngineManager.MostValuableClients();
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> MostCallingToCenterClients()
        {
            var task = Task.Factory.StartNew(() =>
              {
                  var a = _reportsEngineManager.MostCallingToCenterClients();
                  return a;
              });
            return await task.ConfigureAwait(false);
        }

        //public StringBuilder GetGroups()
        //{
        //    return _reportsEngineManager.GetGroups();
        //}
    }
}