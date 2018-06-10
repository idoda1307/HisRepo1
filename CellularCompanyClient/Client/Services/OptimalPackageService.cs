using Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class OptimalPackageService: IOptimalPackageService
    {
        OptimalPackageServiceReference.OptimalPackageServiceClient client = new OptimalPackageServiceReference.OptimalPackageServiceClient();
        public async Task<double> CalaculateTotalMinutes(int lineId)
        {
            return await client.CalaculateTotalMinutesAsync(lineId);
        }

        public async Task<double> CalculateClientValue(string clientId)
        {
            return await client.CalculateClientValueAsync(clientId);
        }

        public async Task<double> CalculateTotalMinutesOf3TopNumbers(int lineId)
        {
            return await client.CalculateTotalMinutesOf3TopNumbersAsync(lineId);
        }

        public async Task<double> CalculateTotalMinutesOfTopNumber(int lineId)
        {
            return await client.CalculateTotalMinutesOfTopNumberAsync(lineId);
        }

        public async Task<double> CalculateTotalMinutesWithFamily(int lineId)
        {
            return await client.CalculateTotalMinutesWithFamilyAsync(lineId);
        }

        public async Task<int> CalculateTotalSMS(int lineId)
        {
            return await client.CalculateTotalSMSAsync(lineId);
        }
    }
}
