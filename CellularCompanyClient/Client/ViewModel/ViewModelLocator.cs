using Client.Infrastructure;
using Client.Pages;
using Client.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Diagnostics;

namespace Client.ViewModel
{
    public class ViewModelLocator
    {
        public const string FirstPageKey = "FirstPage";
        public const string CustomerPageKey = "CustomersPage";
        public const string LinesPageKey = "LinesPage";
        public const string SimulatorPageKey = "SimulatorPage";
        public const string PaymentPageKey = "PaymentPage";
        public const string PaymentViewPageKey = "PaymentView";
        public const string ManagersPageKey = "ManagersPage";
        public const string OPtimalPackagePageKey = "OptimalPage";

        public ViewModelLocator()
        {
            try
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                //navigation
                var nav = new NavigationService();
                nav.Configure(FirstPageKey, typeof(MainPage));
                nav.Configure(CustomerPageKey, typeof(CustomerPage));
                nav.Configure(LinesPageKey, typeof(LinePage));
                nav.Configure(SimulatorPageKey, typeof(SimulatorPage));
                nav.Configure(PaymentPageKey, typeof(CalculateBillingPage));
                nav.Configure(PaymentViewPageKey, typeof(BillingsViewPage));
                nav.Configure(ManagersPageKey, typeof(ManagersPage));
                nav.Configure(OPtimalPackagePageKey, typeof(OptimalPackagePage));
                //Register your services used here
                SimpleIoc.Default.Register<INavigationService>(() => nav);
                SimpleIoc.Default.Register<IClientService, ClientService>();
                SimpleIoc.Default.Register<ILineService, LineService>();
                SimpleIoc.Default.Register<ISimulatorService, SimulatorService>();
                SimpleIoc.Default.Register<IManagerService, ManagerService>();
                SimpleIoc.Default.Register<IInvoiceService, InvoiceService>();
                //register view models
                SimpleIoc.Default.Register<MainViewModel>();
                SimpleIoc.Default.Register<ClientViewModel>();
                SimpleIoc.Default.Register<LinesViewModel>();
                SimpleIoc.Default.Register<SimulatorViewModel>();
                SimpleIoc.Default.Register<PaymentCalculationViewModel>();
                SimpleIoc.Default.Register<PaymentViewViewModel>();
                SimpleIoc.Default.Register<ManagersViewModel>();
                SimpleIoc.Default.Register<OptimalPackageViewModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public MainViewModel MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ClientViewModel ClientVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClientViewModel>();
            }
        }

        public LinesViewModel LineVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LinesViewModel>();
            }
        }

        public SimulatorViewModel SimulatorVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SimulatorViewModel>();
            }
        }

        public PaymentCalculationViewModel PaymentCalculationVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PaymentCalculationViewModel>();
            }
        }

        public PaymentViewViewModel PaymentViewVM
        {
            get
            {
                try
                {
                    return ServiceLocator.Current.GetInstance<PaymentViewViewModel>();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public ManagersViewModel ManagersVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManagersViewModel>();
            }
        }

        public OptimalPackageViewModel OptimalVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OptimalPackageViewModel>();
            }
        }



        public static void Cleanup()
        {
        }
    }
}