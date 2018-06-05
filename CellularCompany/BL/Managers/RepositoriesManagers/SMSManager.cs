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
    public class SMSManager: ISMSManager
    {
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SMSRepository>()
                    .As<ISMSRepository>()
                    .SingleInstance();
            return builder.Build();
        }

        public async Task<SMSDto> AddSMSDto(SMSDto dto)
        {
            return await GetContainer().Resolve<ISMSRepository>().CreateSMS(dto);
        }

        public SMSDto GetSMSDto(int smsId)
        {
            return GetContainer().Resolve<ISMSRepository>().GetSMS(smsId);
        }

        public IEnumerable<SMSDto> GetSMSDtos(string clientId)
        {
            return GetContainer().Resolve<ISMSRepository>().GetSMSs(clientId);
        }
    }
}
