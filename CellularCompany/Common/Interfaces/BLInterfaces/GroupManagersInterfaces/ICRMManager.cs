using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.GroupManagersInterfaces
{
    public interface ICRMManager
    {
        Task<ClientDto> AddClient(ClientDto client);
        //Task<PackageIncludesDto> AddPackageIncludes(PackageIncludesDto packageIncludesDto);
        //Task<SelectedNumbersDto> AddSelectedNumbers(SelectedNumbersDto selectedNumbersDto);
        Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers);
        Task<PackageDto> AddPackage(PackageDto package, PackageIncludesDto packageIncludes);

        Task<bool> RemoveClient(string id);
        Task<bool> RemoveLine(int id);

        Task<ClientDto> UpdateClient(ClientDto client, string clientId);
        //Task<ClientDto> UpdateClientClientType(int typeId, ClientDto client);
        //Task<PackageDto> UpdatePackage(int packageId, PackageDto package);
        Task<LineDto> UpdateLine(int lineId, LineDto line);
        Task<PackageDto> UpdatePackage(PackageDto package, int packageId);
        //Task<PackageIncludesDto> UpdatePackageIncludes(int id, PackageIncludesDto packageIncludes);

        ClientTypeDto GetClientType(int typeId);
        PackageDto GetLinePackage(int lineId);
        PackageIncludesDto GetLinePackageIncludes(int packageId);
        //LineDto GetLine(int lineId);
        //ClientDto GetClient(string clientId);

        IEnumerable<string> GetSelectedNumbers(int lineId);
        IEnumerable<ClientDto> GetClients();
        IEnumerable<string> GetClientsIds();
        IEnumerable<ClientTypeDto> GetClientTypes();
        IEnumerable<LineDto> GetLines();
        IEnumerable<PackageDto> GetPackages();
        IEnumerable<LineDto> GetDestinationLines(int lineId);
        IEnumerable<LineDto> GetLines(string clientId);
    }
}
