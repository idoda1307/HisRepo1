using Autofac;
using BL.ModulesRegistration;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GroupManagers.Managers
{
    public class ReportsEngineManager : IReportsEngineManager
    {
        private readonly IClientTypeManager _clientTypeManager;
        private readonly ISMSManager _smsManager;
        private readonly ICallManager _callManager;
        private readonly IClientManager _clientManager;
        private readonly IPackageManager _packageManager;
        private readonly ILineManager _lineManager;
        private readonly ICRMManager _crmManager;
        public ReportsEngineManager()
        {
            _clientTypeManager = GetContainer().Resolve<IClientTypeManager>();
            _smsManager = GetContainer().Resolve<ISMSManager>();
            _callManager = GetContainer().Resolve<ICallManager>();
            _clientManager = GetContainer().Resolve<IClientManager>();
            _packageManager = GetContainer().Resolve<IPackageManager>();
            _lineManager = GetContainer().Resolve<ILineManager>();
            _crmManager = GetContainer().Resolve<ICRMManager>();
        }

        public IContainer GetContainer()
        {
            return ModulesRegistrations.RegisterReportsEngine();
        }

        //public IEnumerable<LineDto> GetClientMostCalledNumbers(string clientId)
        //{
        //    Dictionary<string, int> dictionary = new Dictionary<string, int>();
        //    List<string> mostConnectedNumbers = _smsManager.GetSMSDtos(clientId).Select(s => s.DestinationNumber).ToList();
        //    mostConnectedNumbers.AddRange(_callManager.GetCallsDtos(clientId).Select(s => s.DestinationNumber).ToList());
        //    foreach (var i in mostConnectedNumbers)
        //    {
        //        if (!dictionary.Keys.Contains(i))
        //            dictionary.Add(i, 1);
        //        else
        //            dictionary[i]++;
        //    }
        //    List<string> list = dictionary.Keys.Take(3).ToList();
        //    List<LineDto> lines = new List<LineDto>();
        //    foreach (var i in list)
        //    {
        //        if (_lineManager.GetLineByNumber(i) != null)
        //        {
        //            LineDto line = _lineManager.GetLineByNumber(i);
        //            lines.Add(line);
        //        }
        //    }
        //    return lines;
        //}

        public IEnumerable<string> MostCallingToCenterClients()
        {
            List<ClientDto> list = _clientManager.GetClientDtos().ToList();
            var clients = (from c in list
                           orderby c.CallsToCenter descending
                           select ($"{c.FirstName} {c.LastName} called to center {c.CallsToCenter} times")).Take(3);
            return clients;
        }

        public IEnumerable<string> MostValuableClients()
        {
            Dictionary<ClientDto, double> dictionary = new Dictionary<ClientDto, double>();
            foreach (var item in _clientManager.GetClientDtos())
            {
                ClientTypeDto clientType = _clientTypeManager.GetClientTypeDto(item.ClientTypeId);
                double value = GetCallsPrice(item, clientType) + GetPackageIncludesPrice(item) + GetPackagePrice(item) + GetSmsPrice(item, clientType);
                dictionary.Add(item, value);
            }
            var sortedDictionary = from v in dictionary
                                   orderby v.Value descending
                                   select v;
            List<string> list = new List<string>();
            foreach (var item in sortedDictionary)
            {
                list.Add($"{item.Key.FirstName} {item.Key.LastName} has a value of {item.Value}");
            }
            return list.Take(3);
        }

        public double GetPackagePrice(ClientDto item)
        {
            List<int> packageIds = _crmManager.GetLines(item.ClientId).Select(p => p.PackageId).ToList();
            double totalLinesPackagesPrice = 0;
            if (packageIds != null)
            {
                foreach (var i in packageIds)
                    totalLinesPackagesPrice += _packageManager.GetPackageDto(i).PackageTotalPrice;
            }
            return totalLinesPackagesPrice;
        }

        public double GetPackageIncludesPrice(ClientDto item)
        {
            List<int> packageIds = _lineManager.GetClientLines(item.ClientId).Select(p => p.PackageId).ToList();
            double packageIncludePriceSum = 0;
            foreach (var id in packageIds)
            {
                var packageIncludes = _packageManager.GetPackageIncludes(id);
                packageIncludePriceSum += packageIncludes.FixedPrice * (1 - (packageIncludes.DiscountPrecentage / 100));
            }
            return packageIncludePriceSum;
        }

        public double GetSmsPrice(ClientDto item, ClientTypeDto clientType)
        {
            double smsPrice = clientType.SMSPrice;
            List<SMSDto> smss = _smsManager.GetSMSDtos(item.ClientId).Where(s => s.Time.Month == DateTime.Now.Month).ToList();
            double totalPrice = 0;
            foreach (var sms in smss)
            {
                if (sms != null)
                    totalPrice += sms.ExternalPrice + smsPrice;
            }
            return totalPrice;
        }

        public double GetCallsPrice(ClientDto item, ClientTypeDto clientType)
        {
            double callPrice = clientType.MinutePrice;
            List<CallsDto> calls = _callManager.GetCallsOfClient(item.ClientId).Where(c => c.Time.Month == DateTime.Now.Month).ToList();
            double totalPrice = 0;
            foreach (var call in calls)
            {
                if (call != null)
                    totalPrice += call.ExternalPrice + callPrice;
            }
            return totalPrice;
        }
    }
}
