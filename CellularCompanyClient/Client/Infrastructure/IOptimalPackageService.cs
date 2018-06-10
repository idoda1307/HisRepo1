using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface IOptimalPackageService
    {
        Task<double> CalaculateTotalMinutes(int lineId);
        Task<double> CalculateClientValue(string clientId);
        Task<double> CalculateTotalMinutesOf3TopNumbers(int lineId);
        Task<double> CalculateTotalMinutesOfTopNumber(int lineId);
        Task<double> CalculateTotalMinutesWithFamily(int lineId);
        Task<int> CalculateTotalSMS(int lineId);
    }
}
