using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentDto> CreatePayment(PaymentDto payment);
        Task<bool> DeletePayment(int id);
        Task<PaymentDto> UpdatePayment(PaymentDto payment, int id);
        PaymentDto GetPayment(int id);
        IEnumerable<PaymentDto> GetPayments();
    }
}
