using Client.DataShare;
using Client.Infrastructure;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
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
            _navigationService = navigationService;
            _invoiceService = invoiceService;
            _invoice = TransformModel.Invoice;
            ClientName = _invoice.Client.FirstName + " " + _invoice.Client.LastName;
            Month = _invoice.Date.Month;
            Package = _invoiceService.GetPackage(_invoice.Line.LineId).Result;
        }
    }
}