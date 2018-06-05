using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface IClientRepository
    {
        Task<ClientDto> CreateClient(ClientDto client);
        Task<bool> DeleteClient(string id);
        Task<ClientDto> UpdateClient(ClientDto client, string clientId);
        ClientDto GetClient(string id);
        List<ClientDto> GetClients();
        IEnumerable<LineDto> GetClientLines(string clientId);
    }
}
