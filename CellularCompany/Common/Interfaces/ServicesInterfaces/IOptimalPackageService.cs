using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.ServicesInterfaces
{
    [ServiceContract]
    public interface IOptimalPackageService
    {
        [OperationContract]
        Task<double> CalaculateTotalMinutes(int lineId);
        [OperationContract]
        Task<int> CalculateTotalSMS(int lineId);
        [OperationContract]
        Task<double> CalculateTotalMinutesOfTopNumber(int lineId);
        [OperationContract]
        Task<double> CalculateTotalMinutesOf3TopNumbers(int lineId);
        [OperationContract]
        Task<double> CalculateTotalMinutesWithFamily(int lineId);
        [OperationContract]
        Task<double> CalculateClientValue(string clientId);
    }
}
