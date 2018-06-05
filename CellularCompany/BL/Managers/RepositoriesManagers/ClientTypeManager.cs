using Autofac;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Interfaces.RepositoryInterfaces;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.RepositoriesManagers
{
    public class ClientTypeManager:IClientTypeManager
    {
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClientTypeRepository>()
                    .As<IClientTypeRepository>()
                    .SingleInstance();
            return builder.Build();
        }

        public ClientTypeDto GetClientTypeDto(int typeId)
        {
            return GetContainer().Resolve<IClientTypeRepository>().GetClientType(typeId);
        }

        public IEnumerable<ClientTypeDto> GetClientTypesDto()
        {
            return GetContainer().Resolve<IClientTypeRepository>().GetClientTypes();
        }
    }
}
