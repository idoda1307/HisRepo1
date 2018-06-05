using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.ServicesInterfaces
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        Task<SMSDto> AddSMS(SMSDto sms);
        [OperationContract]
        Task<CallsDto> AddCall(CallsDto call);
        [OperationContract]
        Task<IEnumerable<LineDto>> GetDestinationLines(int lineId);
        [OperationContract]
        Task<PackageDto> GetLinePackage(int lineId);
    }
}
