using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface ICallsRepository
    {
        Task<CallsDto> CreateCall(CallsDto call);
        CallsDto GetCall(int id);
        IEnumerable<CallsDto> GetCalls(int lineId);
        IEnumerable<CallsDto> GetCallsOfClient(string clientId);
        double GetNumberOfMinutes(LineDto line, PackageIncludesDto packageIncludes);
    }
}
