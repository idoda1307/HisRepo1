using Autofac;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Interfaces.RepositoryInterfaces;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.RepositoriesManagers
{
   public class ClientManager: IClientManager
    {
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClientRepository>()
                    .As<IClientRepository>()
                    .SingleInstance();
            return builder.Build();
        }

        public async Task<ClientDto> AddClientDto(ClientDto dto)
        {
            return await GetContainer().Resolve<IClientRepository>().CreateClient(dto);
        }

        public async Task<bool> RemoveClientDto(string clientId)
        {
            return await GetContainer().Resolve<IClientRepository>().DeleteClient(clientId);
        }

        public async Task<ClientDto> UpdateClientDto(ClientDto dto,string clientId)
        {
            return await GetContainer().Resolve<IClientRepository>().UpdateClient(dto,clientId);
        }

        public ClientDto GetClientDto(string clientId)
        {
            return GetContainer().Resolve<IClientRepository>().GetClient(clientId);
        }

        public IEnumerable<ClientDto> GetClientDtos()
        {
            try
            {
                return GetContainer().Resolve<IClientRepository>().GetClients();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //public async Task<ClientDto> UpdateClientClientType(ClientDto dto,int type)
        //{
        //    return await GetContainer().Resolve<IClientRepository>().UpdateClientClientType(dto, type);
        //}

        public IEnumerable<string> GetClientsIds()
        {
            return GetContainer().Resolve<IClientRepository>().GetClients().Select(c=>c.ClientId).ToList();
        }

        //public bool CheckIfClientIdExist(string clientId)
        //{
        //    foreach(var client in GetContainer().Resolve<IClientRepository>().GetClients())
        //    {
        //        if (client.ClientId == clientId)
        //            return true;
        //    }
        //    return false;
        //}
    }
}
