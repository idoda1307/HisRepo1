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
    public class PaymentManager: IPaymentManager
    {
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PaymentRepository>()
                    .As<IPaymentRepository>()
                    .SingleInstance();
            return builder.Build();
        }

        public async Task<PaymentDto> AddPaymentDto(PaymentDto dto)
        {
            return await GetContainer().Resolve<IPaymentRepository>().CreatePayment(dto);
        }

        public async Task<bool> RemovePaymentDto(int paymentId)
        {
            return await GetContainer().Resolve<IPaymentRepository>().DeletePayment(paymentId);
        }

        public async Task<PaymentDto> UpdatePaymentDto(PaymentDto dto,int id)
        {
            return await GetContainer().Resolve<IPaymentRepository>().UpdatePayment(dto,id);
        }

        public PaymentDto GetPaymentDto(int paymentId)
        {
            return GetContainer().Resolve<IPaymentRepository>().GetPayment(paymentId);
        }

        public IEnumerable<PaymentDto> GetPaymentDtos()
        {
            return GetContainer().Resolve<IPaymentRepository>().GetPayments();
        }
    }
}
