using Client.ReportsEngineServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface IManagerService
    {
        Task<IEnumerable<string>> GetMostValuableClients();
        Task<IEnumerable<string>> GetMostCallingToCenter();
        //Task<StringBuilder> GetGroups();
    }
}
