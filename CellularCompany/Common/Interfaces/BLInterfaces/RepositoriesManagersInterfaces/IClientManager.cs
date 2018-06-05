using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces
{
    public interface IClientManager
    {
        Task<ClientDto> AddClientDto(ClientDto dto);
        Task<bool> RemoveClientDto(string clientId);
        Task<ClientDto> UpdateClientDto(ClientDto dto,string clientId);
        ClientDto GetClientDto(string clientId);
        IEnumerable<ClientDto> GetClientDtos();
        //Task<ClientDto> UpdateClientClientType(ClientDto dto, int type);
        IEnumerable<string> GetClientsIds();
        //bool CheckIfClientIdExist(string clientId);
    }
}
