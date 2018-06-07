using Client.DataShare;
using Client.Infrastructure;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class PaymentViewViewModel : ViewModelBase
    {
        //properties
        public string ClientName { get; set; }
        public int Month { get; set; }
        public PackageModel Package { get; set; }
        public PackageIncludesModel PackageIncludes { get; set; }
        public double MinutesLeft { get; set; }
        public double MinutesBeyondLimit { get; set; }
        public ClientTypeModel ClientType { get; set; }

        private InvoiceModel _invoice;
        public InvoiceModel Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                RaisePropertyChanged(nameof(Invoice));
            }
        }

        private readonly INavigationService _navigationService;
        private readonly IInvoiceService _invoiceService;

        public PaymentViewViewModel(INavigationService navigationService,IInvoiceService invoiceService)
        {
            try
            {
                _navigationService = navigationService;
                _invoiceService = invoiceService;
                _invoice = TransformModel.Invoice;
                ClientName = _invoice.Client.FirstName + " " + _invoice.Client.LastName;
                Month = _invoice.Date.Month;
                var package=Task.Factory.StartNew(()=>_invoiceService.GetPackage(_invoice.Line.LineId));
                Package = package.Result.Result;
                var includes =Task.Factory.StartNew(()=> _invoiceService.GetPackageIncludes(Package.PackageId));
                PackageIncludes = includes.Result.Result;
                var minutes =Task.Factory.StartNew(()=> _invoiceService.GetMinutesLeft(PackageIncludes, _invoice.Line));
                MinutesLeft = minutes.Result.Result;
                var type = Task.Factory.StartNew(() => _invoiceService.GetClientType(_invoice.Client.ClientTypeId));
                ClientType = type.Result.Result;
                var beyondLimit = Task.Factory.StartNew(() => _invoiceService.MinutesBeyondLimit(_invoice.Line, PackageIncludes));
                MinutesBeyondLimit = beyondLimit.Result.Result;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}