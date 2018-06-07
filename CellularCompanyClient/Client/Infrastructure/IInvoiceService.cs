using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface IInvoiceService
    {
        Task<PackageModel> GetPackage(int lineId);
        Task<PackageIncludesModel> GetPackageIncludes(int packageId);
        Task<double> GetMinutesLeft(PackageIncludesModel packageIncludes, LineModel line);
        Task<ClientTypeModel> GetClientType(int typeId);
        Task<double> MinutesBeyondLimit(LineModel line, PackageIncludesModel packageIncludes);
    }
}
