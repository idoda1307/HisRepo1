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
        [OperationContract]
        Task<PackageIncludesDto> GetLinePackageIncludes(int packageId);
        [OperationContract]
        Task<double> CalculateNumberOfMinutesLeftInPackage(int minutesInPackage, LineDto line);
        [OperationContract]
        Task<ClientTypeDto> GetClientType(int clientTypeId);
        [OperationContract]
        Task<double> GetNumberOfMinutes(LineDto line, PackageIncludesDto packageIncludes);
    }
}
