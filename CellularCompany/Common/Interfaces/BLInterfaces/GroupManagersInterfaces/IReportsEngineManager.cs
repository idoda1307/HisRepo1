using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.GroupManagersInterfaces
{
    public interface IReportsEngineManager
    {
        IEnumerable<string> MostValuableClients();
        IEnumerable<string> MostCallingToCenterClients();
        //StringBuilder GetGroups();
    }
}
