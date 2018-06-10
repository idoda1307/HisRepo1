using Autofac;
using Autofac.Integration.Wcf;
using BL.GroupManagers.Managers;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Services
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CRMManager>().As<ICRMManager>();
            builder.RegisterType<CRMService>().AsSelf();

            builder.RegisterType<InvoiceManager>().As<IInvoiceManager>();
            builder.RegisterType<InvoiceService>().AsSelf();

            builder.RegisterType<OptimalPackageManager>().As<IOptimalPackageManager>();
            builder.RegisterType<OptimalPackageService>().AsSelf();

            builder.RegisterType<ReportsEngineManager>().As<IReportsEngineManager>();
            builder.RegisterType<ReportsEngineService>().AsSelf();

            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}