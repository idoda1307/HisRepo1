using Client.CRMServiceReference;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface IClientService
    {
        Task<IEnumerable<ClientTypeModel>> GetClientTypes();
        Task<IEnumerable<string>> GetClientsIds();
        Task<ClientDto> AddClient(ClientModel model);
        Task<ClientDto> UpdateClient(string clientId, ClientModel model);
        Task<bool> RemoveClient(string clientId);
        //Task<bool> CheckIfClientIdExist(string clientId);
    }
}
