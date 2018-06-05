using Autofac;
using BL.ModulesRegistration;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GroupManagers.Managers
{
    public class OptimalPackageManager: IOptimalPackageManager
    {
        private IContainer GetContainer()
        {
            return ModulesRegistrations.RegisterOptimalPackageModule();
        }

        public void FindOptimalPackage()
        {

        }
    }
}
