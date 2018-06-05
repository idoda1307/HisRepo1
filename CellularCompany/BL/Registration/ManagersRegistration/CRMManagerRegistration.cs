using Autofac;
using BL.GroupManagers.Managers;
using BL.Managers;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registration.ManagersRegistration
{
    public class CRMManagerRegistration:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CRMManager>()
                .As<ICRMManager>()
                .SingleInstance();
            base.Load(builder);
        }
    }
}
