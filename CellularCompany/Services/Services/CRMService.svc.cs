using Common.Interfaces.BLInterfaces.GroupManagersInterfaces;
using Common.Interfaces.ServicesInterfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CRMService : ICRMService
    {
        private readonly ICRMManager _manager;

        public CRMService(ICRMManager manager)
        {
            _manager = manager;
        }

        public async Task<ClientDto> AddClient(ClientDto client)
        {
            return await _manager.AddClient(client);
        }

        public async Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers)
        {
            return await _manager.AddLineEntity(line, selectedNumbers);
        }

        public async Task<PackageDto> AddPackage(PackageDto package,PackageIncludesDto packageIncludes)
        {
            return await _manager.AddPackage(package,packageIncludes);
        }

        public async Task<bool> RemoveClient(string id)
        {
            return await _manager.RemoveClient(id);
        }

        public async Task<bool> RemoveLine(int lineId)
        {
            return await _manager.RemoveLine(lineId);
        }

        public async Task<ClientDto> UpdateClient(string id, ClientDto client)
        {
            return await _manager.UpdateClient(client, id);
        }

        public async Task<LineDto> UpdateLine(LineDto line, int lineId)
        {
            return await _manager.UpdateLine(lineId, line);
        }

        public async Task<PackageDto> UpdatePackage(PackageDto package,int packageId)
        {
            return await _manager.UpdatePackage(package, packageId);
        }

        public async Task<IEnumerable<ClientTypeDto>> GetClientTypes()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.GetClientTypes().ToList();
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.GetClients().ToList();
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> GetClientsIds()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.GetClientsIds().ToList();
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<LineDto>> GetLinesOfClient(string clientId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var a = _manager.GetLines(clientId).ToList();
                return a;
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<PackageDto>> GetPackages()
        {
            var task = Task.Factory.StartNew(() =>
              {
                  return _manager.GetPackages().ToList();
              });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> GetSelectedNumbers(int lineId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return _manager.GetSelectedNumbers(lineId);
            });
            return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<LineDto>> GetLines()
        {
            var task = Task.Factory.StartNew(() =>
              {
                  return _manager.GetLines();
              });
            return await task.ConfigureAwait(false);
        }
    }
}