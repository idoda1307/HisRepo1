using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces
{
    public interface IPaymentManager
    {
        Task<PaymentDto> AddPaymentDto(PaymentDto dto);
        Task<bool> RemovePaymentDto(int paymentId);
        Task<PaymentDto> UpdatePaymentDto(PaymentDto dto,int id);
        PaymentDto GetPaymentDto(int paymentId);
        IEnumerable<PaymentDto> GetPaymentDtos();
    }
}
