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

        public async Task<double> GetMinutesLeft(PackageIncludesModel packageIncludes,LineModel line)
        {
            return await invoice.CalculateNumberOfMinutesLeftInPackageAsync(packageIncludes.MaxMinute, line.ToDto1());

        }

        public async Task<ClientTypeModel> GetClientType(int typeId)
        {
            ClientTypeDto dto= await invoice.GetClientTypeAsync(typeId);
            return dto.ToModel1();
        }

        public async Task<double> MinutesBeyondLimit(LineModel line,PackageIncludesModel packageIncludes)
        {
            return await invoice.GetNumberOfMinutesAsync(line.ToDto1(), packageIncludes.ToDto1());
        }
    }
}
