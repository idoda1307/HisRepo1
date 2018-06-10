using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.GroupManagersInterfaces
{
    public interface IOptimalPackageManager
    {
        double CalaculateTotalMinutes(int lineId);
        int CalculateTotalSMS(int lineId);
        double CalculateTotalMinutesOfTopNumber(int lineId);
        double CalculateTotalMinutesOf3TopNumbers(int lineId);
        double CalculateTotalMinutesWithFamily(int lineId);
        double CalculateClientValue(string clientId);
    }
}
