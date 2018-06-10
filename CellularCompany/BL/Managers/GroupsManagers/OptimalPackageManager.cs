using Autofac;
using BL.ModulesRegistration;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GroupManagers.Managers
{
    public class OptimalPackageManager: IOptimalPackageManager
    {
        Object obj = new Object();
        private readonly ICRMManager crmManager;
        private readonly IPackageManager packageManager;
        private readonly ISMSManager smsManager;
        private readonly ILineManager lineManager;
        private readonly ICallManager callManager;

        public OptimalPackageManager()
        {
            packageManager = GetContainer().Resolve<IPackageManager>();
            crmManager = GetContainer().Resolve<ICRMManager>();
            smsManager = GetContainer().Resolve<ISMSManager>();
            callManager = GetContainer().Resolve<ICallManager>();
            lineManager = GetContainer().Resolve<ILineManager>();
        }

        private IContainer GetContainer()
        {
            return ModulesRegistrations.RegisterOptimalPackageModule();
        }

        public double CalaculateTotalMinutes(int lineId)
        {
            lock(obj)
            {
                double minutes = callManager.GetCallsDtos(lineId).Sum(c => c.Duration);
                return minutes;
            }
        }

        public int CalculateTotalSMS(int lineId)
        {
            lock(obj)
            {
                int numOfSms = smsManager.GetSmssOfLine(lineId).Count();
                return numOfSms;
            }
        }

        public double CalculateTotalMinutesOfTopNumber(int lineId)
        {
            lock(obj)
            {
                string destinationNumber = callManager.GetCallsDtos(lineId).Max(l => l.DestinationNumber);
                if (lineManager.GetLineByNumber(destinationNumber) != null)
                {
                    double totalMinutesOfTopNumber = callManager.GetCallsDtos(lineId).Where(l => l.DestinationNumber == destinationNumber).Sum(l => l.Duration);
                    return totalMinutesOfTopNumber;
                }
                return 0;
            }
        }

        public double CalculateTotalMinutesOf3TopNumbers(int lineId)
        {
            lock (obj)
            {
                List<string> destinationNumbers = callManager.GetCallsDtos(lineId).Select(l => l.DestinationNumber).ToList();
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                foreach (var item in destinationNumbers)
                {
                    if (!dictionary.Keys.Contains(item))
                        dictionary.Add(item, 1);
                    else
                        dictionary[item]++;
                }
                var mostCalledNumbers = dictionary.OrderByDescending(d => d.Value).Take(3);
                double totalMinutes=0;
                foreach (var item in mostCalledNumbers)
                {
                    var line = lineManager.GetLineByNumber(item.Key);
                    if (line!=null)
                    {
                        totalMinutes+= callManager.GetCallsDtos(lineId).Where(l => l.DestinationNumber == item.Key).Sum(l => l.Duration);
                    }
                }
                return totalMinutes;
            }
        }

        public double CalculateTotalMinutesWithFamily(int lineId)
        {
            lock(obj)
            {
                LineDto line = lineManager.GetLineDto(lineId);
                List<string> lines = lineManager.GetLineDtos().Where(l => l.ClientId == line.ClientId).Select(l=>l.Number).ToList();
                List<CallsDto> calls = callManager.GetCallsDtos(lineId).ToList();
                double minutesWithFamily = 0;
                foreach (var item in calls)
                {
                    foreach (var i in lines)
                    {
                        if(item.DestinationNumber==i)
                        {
                            minutesWithFamily += item.Duration;
                        }
                    }
                }
                return minutesWithFamily;
            }
        }

        public double CalculateClientValue(string clientId)
        {
            lock (obj)
            {
                int numOfLines = lineManager.GetClientLines(clientId).Count();
                int callsToCenter = crmManager.GetClient(clientId).CallsToCenter;
                return callsToCenter * (-0.1) + numOfLines * 0.5;
            }
        }

        public IEnumerable<PackageDto> GetOptimalPackage(int lineId)
        {
            lock(obj)
            {
                LineDto line = lineManager.GetLineDto(lineId);
                Dictionary<PackageDto, double> dictionary = new Dictionary<PackageDto, double>();
                foreach (var item in packageManager.GetPackageDtos())
                {
                    PackageIncludesDto packageIncludes = packageManager.GetPackageIncludes(item.PackageId);
                    if(packageIncludes.InsideFamilyCalls==true)
                    {
                        dictionary.Add(item, CalculateTotalMinutesWithFamily(lineId) * packageIncludes.DiscountPrecentage);
                    }
                    if(packageIncludes.MostCalledNumber==true)
                    {
                        dictionary.Add(item, CalculateTotalMinutesOfTopNumber(lineId) * packageIncludes.DiscountPrecentage);
                    }

                }
                return dictionary.OrderBy(v=>v.Value).Select(k=>k.Key);
            }
        }
    }
}
