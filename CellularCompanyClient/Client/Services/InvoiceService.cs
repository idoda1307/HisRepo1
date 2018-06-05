using Client.Infrastructure;
using Client.InvoiceServiceReference;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class InvoiceService: Infrastructure.IInvoiceService
    {
        InvoiceServiceReference.InvoiceServiceClient invoice = new InvoiceServiceReference.InvoiceServiceClient();
        
        public async Task<PackageModel> GetPackage(int lineId)
        {
            PackageDto a= await invoice.GetLinePackageAsync(lineId);
            return a.ToModel();
        }

        public async Task<PackageIncludesModel> GetPackageIncludes(int packageId)
        {
            PackageIncludesDto a = await invoice.GetLinePackageIncludesAsync(packageId);
            return a.ToModel();
        }
    }
}
