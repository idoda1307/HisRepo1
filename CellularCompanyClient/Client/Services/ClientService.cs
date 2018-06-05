using Client.CRMServiceReference;
using Client.Infrastructure;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ClientService: IClientService
    {
        CRMServiceClient crm = new CRMServiceClient();
        public async Task<IEnumerable<ClientTypeModel>> GetClientTypes()
        {
            try
            {
                List<ClientTypeDto> ClientTypes = await crm.GetClientTypesAsync();
                List<ClientTypeModel> clientTypeList = ClientTypes.Select(c => c.ToModel()).ToList();
                return clientTypeList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<string>> GetClientsIds()
        {
            return await crm.GetClientsIdsAsync();
        }

        public async Task<ClientDto> AddClient(ClientModel model)
        {
            return await crm.AddClientAsync(model.ToDto());
        }

        public async Task<ClientDto> UpdateClient(string clientId,ClientModel model)
        {
            return await crm.UpdateClientAsync(clientId, model.ToDto());
        }

        public async Task<bool> RemoveClient(string clientId)
        {
            return await crm.RemoveClientAsync(clientId);
        }

        //public async Task<bool> CheckIfClientIdExist(string clientId)
        //{
        //    try
        //    {
        //        var a = await crm.CheckIfClientIdAlreadyExistAsync(clientId);
        //        return a;
        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return false;
        //    }
        //}
    }
}
