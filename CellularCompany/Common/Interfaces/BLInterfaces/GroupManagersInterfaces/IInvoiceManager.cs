using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.GroupManagersInterfaces
{
    public interface IInvoiceManager
    {
        Task<CallsDto> CreateCall(CallsDto call);
        Task<SMSDto> CreateSMS(SMSDto sms);
        IEnumerable<LineDto> GetDestinationLines(int lineId);
        PackageDto GetLinePackage(int lineId);
        PackageIncludesDto GetLinePackageIncludes(int packageId);
        double CalculateNumberOfMinutesLeftInPackage(int minutesInPackage, LineDto line);
        ClientTypeDto GetClientType(int typeId);
        double GetNumberOfMinutes(LineDto line, PackageIncludesDto packageIncludes);
    }
}
