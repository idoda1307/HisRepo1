using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.ServicesInterfaces
{
    [ServiceContract]
    public interface IReportsEngineService
    {
        [OperationContract]
        Task<IEnumerable<string>> MostValuableClients();
        [OperationContract]
        Task<IEnumerable<string>> MostCallingToCenterClients();
        //[OperationContract]
        //StringBuilder GetGroups();
    }
}
