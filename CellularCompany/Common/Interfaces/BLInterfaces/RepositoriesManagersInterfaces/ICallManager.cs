using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces
{
    public interface ICallManager
    {
        Task<CallsDto> AddCallDto(CallsDto dto);
        CallsDto GetCallDto(int callId);
        IEnumerable<CallsDto> GetCallsDtos(string clientId);
    }
}
