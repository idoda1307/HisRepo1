using Autofac;
using BL.ModulesRegistration;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Interfaces.RepositoryInterfaces;
using Common.Models;
using DAL;
using DAL.Models;
using DAL.Repositories;
using Dtos;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GroupManagers.Managers
{
    public class InvoiceManager: IInvoiceManager
    {
        Object obj = new Object();
       private readonly ICallManager callManager;
       private readonly ISMSManager smsManager;
        private readonly ICRMManager crmManager;

        public InvoiceManager()
        {
            callManager = GetContainer().Resolve<ICallManager>();
            smsManager = GetContainer().Resolve<ISMSManager>();
        }

        private IContainer GetContainer()
        {
            return ModulesRegistrations.RegisterInvoiceModule();
        }

        public async Task<CallsDto> CreateCall(CallsDto call)
        {
            Task<CallsDto> callDto;
            lock(obj)
            {
                callDto = callManager.AddCallDto(call);
            }
            return await callDto;
        }

        public async Task<SMSDto> CreateSMS(SMSDto sms)
        {
            Task<SMSDto> smsDto;
            lock (obj)
            {
                smsDto = smsManager.AddSMSDto(sms);
            }
            return await smsDto;
        }

        public IEnumerable<LineDto> GetDestinationLines(int lineId)
        {
            lock(obj)
            {
                return crmManager.GetDestinationLines(lineId);
            }
        }

        public PackageDto GetLinePackage(int lineId)
        {
            lock (obj)
            {
                return crmManager.GetLinePackage(lineId);
            }
        }

        public void GetDetails(PaymentDto payment)
        {
            List<LineDto> lines = payment.Client.Lines.ToList();
            double callsExternalPrice = lines.Sum(l => l.Calls.Sum(c=>c.ExternalPrice));
            double smsExternalPrice = lines.Sum(l => l.SMS.Sum(s => s.ExternalPrice));
            double minutePrice = payment.Client.ClientType.MinutePrice;
            double smsPrice = payment.Client.ClientType.SMSPrice;
            int numberOfSms= lines.Select(l => l.SMS).Count();
            double packagesPrice = lines.Sum(l => l.Package.PackageTotalPrice);
            //payment.TotalPayment = minutePrice * numberOfCalls + smsPrice * numberOfSms+packagesPrice+callsExternalPrice+smsExternalPrice;
        }

        public void ExportDataToExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                
                List<string[]> headerRow = new List<string[]>()
                {
                 new string[] { "Line", "Permanent Billings", "Changed Billings", "Packages Use" }
                };
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FileInfo excelFile = new FileInfo(@"C:\Users\idoda\Desktop\MonthlyBilling\test.xlsx");
                excel.SaveAs(excelFile);
            }
        }
    }
}