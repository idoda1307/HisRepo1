using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OptimalPackageService : IOptimalPackageService
    {
        private readonly IOptimalPackageManager _manager;
        public OptimalPackageService(IOptimalPackageManager manager)
        {
            _manager = manager;
        }

        public async Task<double> CalaculateTotalMinutes(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalaculateTotalMinutes(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<double> CalculateClientValue(string clientId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalculateClientValue(clientId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<double> CalculateTotalMinutesOf3TopNumbers(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalculateTotalMinutesOf3TopNumbers(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<double> CalculateTotalMinutesOfTopNumber(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalculateTotalMinutesOfTopNumber(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<double> CalculateTotalMinutesWithFamily(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalculateTotalMinutesWithFamily(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<int> CalculateTotalSMS(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.CalculateTotalSMS(lineId);
                return a;
            });
            return await task.ConfigureAwait(false);
        }
    }
}
