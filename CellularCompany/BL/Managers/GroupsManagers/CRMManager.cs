using Autofac;
using BL.ModulesRegistration;
using Common.Interfaces;
using Common.Interfaces.BLInterfaces;
using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Models;
using DAL;
using DAL.Models;
using Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GroupManagers.Managers
{
    public class CRMManager : ICRMManager
    {
        Object obj = new Object();
        private readonly IClientManager clientManager;
        private readonly IPackageManager packageManager;
        private readonly IClientTypeManager clientTypeManager;
        private readonly ILineManager lineManager;

        public CRMManager()
        {
            clientManager = ModulesRegistrations.RegisterCRMModule().Resolve<IClientManager>();
            packageManager = ModulesRegistrations.RegisterCRMModule().Resolve<IPackageManager>();
            clientTypeManager = ModulesRegistrations.RegisterCRMModule().Resolve<IClientTypeManager>();
            lineManager = ModulesRegistrations.RegisterCRMModule().Resolve<ILineManager>();
        }

        //crud functions
        //create
        public async Task<ClientDto> AddClient(ClientDto client)
        {
            Task<ClientDto> clientDto;
            lock (obj)
            {
                clientDto = clientManager.AddClientDto(client);
            }
            return await clientDto;
        }

        public async Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers)
        {
            Task<LineDto> lineDto;
            lock (obj)
            {
                lineDto = lineManager.AddLine(line, selectedNumbers);
            }
            return await lineDto;
        }

        public async Task<PackageDto> AddPackage(PackageDto package, PackageIncludesDto packageIncludes)
        {
            Task<PackageDto> packageDto;
            lock (obj)
            {
                packageDto = packageManager.AddPackageDto(package, packageIncludes);
            }
            return await packageDto;
        }

        //delete
        public async Task<bool> RemoveClient(string id)
        {
            Task<bool> isDeleted;
            lock (obj)
            {
                isDeleted = clientManager.RemoveClientDto(id);
            }
            return await isDeleted;
        }

        public async Task<bool> RemoveLine(int id)
        {
            Task<bool> isDeleted;
            lock (obj)
            {
                isDeleted = lineManager.RemoveLineDto(id);
            }
            return await isDeleted;
        }

        //update
        public async Task<ClientDto> UpdateClient(ClientDto client, string clientId)
        {
            Task<ClientDto> clientDto;
            lock (obj)
            {
                clientDto = clientManager.UpdateClientDto(client, clientId);
            }
            return await clientDto;
        }

        public async Task<LineDto> UpdateLine(int lineId, LineDto line)
        {
            Task<LineDto> lineDto;
            lock (obj)
            {
                lineDto = lineManager.UpdateLineDto(line, lineId);
            }
            return await lineDto;
        }

        public async Task<PackageDto> UpdatePackage(PackageDto package, int packageId)
        {
            Task<PackageDto> packageDto;
            lock (obj)
            {
                packageDto = packageManager.UpdatePackageDto(package, packageId);
            }
            return await packageDto;
        }
        //get one
        public ClientTypeDto GetClientType(int typeId)
        {
            lock (obj)
            {
                return clientTypeManager.GetClientTypeDto(typeId);
            }
        }

        public PackageDto GetLinePackage(int lineId)
        {
            lock (obj)
            {
                var line = lineManager.GetLineDto(lineId);
                return packageManager.GetPackageDto(line.PackageId);
            }
        }

        public PackageIncludesDto GetLinePackageIncludes(int packageId)
        {
            lock(obj)
            {
                var include = packageManager.GetPackageIncludes(packageId);
                return include;
            }
        }

        //get many
        public IEnumerable<ClientTypeDto> GetClientTypes()
        {
            lock (obj)
            {
                return clientTypeManager.GetClientTypesDto();
            }
        }

        public IEnumerable<ClientDto> GetClients()
        {
            lock (obj)
            {
                return clientManager.GetClientDtos().ToList();
            }
        }

        public IEnumerable<string> GetClientsIds()
        {
            lock (obj)
            {
                return clientManager.GetClientsIds().ToList();
            }
        }

        public IEnumerable<LineDto> GetLines()
        {
            lock (obj)
            {
                return lineManager.GetLineDtos().ToList();
            }
        }

        public IEnumerable<PackageDto> GetPackages()
        {
            lock (obj)
            {
                return packageManager.GetPackageDtos();
            }
        }

        public IEnumerable<string> GetSelectedNumbers(int lineId)
        {
            lock (obj)
            {
                return lineManager.GetSelectedNumbersByLine(lineId);
            }
        }

        public IEnumerable<LineDto> GetDestinationLines(int lineId)
        {
            lock (obj)
            {
                return lineManager.GetDestinationLines(lineId);
            }
        }

        public IEnumerable<LineDto> GetLines(string clientId)
        {
            lock (obj)
            {
                var a = lineManager.GetClientLines(clientId);
                return a;
            }
        }
    }
}