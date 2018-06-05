using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.ServicesInterfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceManager _manager;

        public InvoiceService(IInvoiceManager manager)
        {
            _manager = manager;
        }

        public async Task<CallsDto> AddCall(CallsDto call)
        {
            return await _manager.CreateCall(call);
        }

        public async Task<SMSDto> AddSMS(SMSDto sms)
        {
            return await _manager.CreateSMS(sms);
        }
        
        public async Task<IEnumerable<LineDto>> GetDestinationLines(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return _manager.GetDestinationLines(lineId);
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<PackageDto> GetLinePackage(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.GetLinePackage(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<PackageIncludesDto> GetLinePackageIncludes(int packageId)
        {
            var task = Task.Factory.StartNew(() =>
              {
                  var a = _manager.GetLinePackageIncludes(packageId);
                  return a;
              });
            return await task.ConfigureAwait(false);
        }
    }
}
