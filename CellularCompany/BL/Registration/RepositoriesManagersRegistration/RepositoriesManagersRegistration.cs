using Autofac;
using BL.Managers.RepositoriesManagers;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registration.RepositoriesManagersRegistration
{
    public class RepositoriesManagersRegistration
    {
        public class CallManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<CallManager>()
                    .As<ICallManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class ClientManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ClientManager>()
                    .As<IClientManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class ClientTypeManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ClientTypeManager>()
                    .As<IClientTypeManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class LineManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<LineManager>()
                    .As<ILineManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class PackageManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<PackageManager>()
                    .As<IPackageManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class PaymentManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<PaymentManager>()
                    .As<IPaymentManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }

        public class SMSManagerRegistration : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<SMSManager>()
                    .As<ISMSManager>()
                    .SingleInstance();
                base.Load(builder);
            }
        }
    }
}
