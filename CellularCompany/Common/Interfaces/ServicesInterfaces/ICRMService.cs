using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.ServicesInterfaces
{
    
    [ServiceContract]
    public interface ICRMService
    {
        [OperationContract]
        Task<ClientDto> AddClient(ClientDto client);
        [OperationContract]
        Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers);
        [OperationContract]
        Task<PackageDto> AddPackage(PackageDto package, PackageIncludesDto packageIncludes);

        [OperationContract]
        Task<bool> RemoveClient(string id);
        [OperationContract]
        Task<bool> RemoveLine(int lineId);

        [OperationContract]
        Task<ClientDto> UpdateClient(string id, ClientDto client);
        [OperationContract]
        Task<LineDto> UpdateLine(LineDto line, int lineId);
        [OperationContract]
        Task<PackageDto> UpdatePackage(PackageDto package, int packageId);
        

        [OperationContract]
        Task<IEnumerable<string>> GetSelectedNumbers(int lineId);
        [OperationContract]
        Task<IEnumerable<ClientTypeDto>> GetClientTypes();
        [OperationContract]
        Task<IEnumerable<ClientDto>> GetClients();
        [OperationContract]
        Task<IEnumerable<string>> GetClientsIds();
        //[OperationContract]
        //IEnumerable<LineDto> GetLines();
        [OperationContract]
        Task<IEnumerable<LineDto>> GetLinesOfClient(string clientId);
        [OperationContract]
        Task<IEnumerable<PackageDto>> GetPackages();
        [OperationContract]
        Task<IEnumerable<LineDto>> GetLines();

        //[OperationContract]
        //bool CheckIfLineNumberAlreadyExist(string number);
        //[OperationContract]
        //Task<bool> CheckIfClientIdAlreadyExist(string clientId);
    }
}