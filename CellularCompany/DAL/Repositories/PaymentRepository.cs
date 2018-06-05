using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Dtos;
using System.Diagnostics;
using Common.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class PaymentRepository: IPaymentRepository
    {
        public async Task<PaymentDto> CreatePayment(PaymentDto payment)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (payment != null)
                    {
                        PaymentEntity entity = payment.ToModel();
                        db.Payment.Add(entity);
                        await db.SaveChangesAsync();
                        return entity.ToDto();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public async Task<bool> DeletePayment(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var payment = db.Payment.FirstOrDefault(p => p.PaymentId == id);
                    if (payment != null)
                    {
                        db.Payment.Remove(payment);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public async Task<PaymentDto> UpdatePayment(PaymentDto payment,int paymentId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (payment != null && paymentId != 0)
                    {
                        payment.PaymentId = paymentId;
                        PaymentEntity entity = payment.ToModel();
                        db.Payment.Attach(entity);
                        foreach (var propName in db.Entry(entity).CurrentValues.PropertyNames)
                        {
                            if (propName != nameof(entity.PaymentId))
                            {
                                db.Entry(entity).Property(propName).IsModified = true;
                            }
                        }
                        await db.SaveChangesAsync();
                        return entity.ToDto();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public PaymentDto GetPayment(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.Payment.FirstOrDefault(p => p.PaymentId == id).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<PaymentDto> GetPayments()
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.Payment.Select(p => p.ToDto()).ToList();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
