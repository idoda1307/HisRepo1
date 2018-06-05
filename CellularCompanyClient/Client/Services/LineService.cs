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
    public class LineService : ILineService
    {
        CRMServiceClient crm = new CRMServiceClient();
        public async Task<LineDto> AddLine(LineModel line,SelectedNumbersModel selectedNumbers)
        {
            try
            {
                //line.Status = LineStatus.available;
                //if (!string.IsNullOrWhiteSpace(selectedNumbers.FirstNumber) || !string.IsNullOrWhiteSpace(selectedNumbers.SecondNumber) || !string.IsNullOrWhiteSpace(selectedNumbers.ThirdNumber))
                //{
                //    //packageIncludes.FavoriteNumbersId = selectedNumbers.Id;
                //    packageIncludes.SelectedNumber = selectedNumbers;
                //}
                //line.PackageIncludes = packageIncludes;
                return await crm.AddLineEntityAsync(line.ToDto(),selectedNumbers.ToDto());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<ClientModel>> GetClients()
        {
            try
            {
                var clients = await crm.GetClientsAsync();
                List<ClientModel> list = clients.Select(c => c.ToModel()).ToList();
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<LineModel>> GetLines(string clientId)
        {
            try
            {
                List<LineDto> lines =await crm.GetLinesOfClientAsync(clientId);
                List<LineModel> linesList = lines.Select(l => l.ToModel()).ToList();
                return linesList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteLine(LineModel line)
        {
            try
            {
                bool isDeleted = await crm.RemoveLineAsync(line.LineId);
                return isDeleted;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<LineDto> UpdateLine(int lineId,LineModel line,SelectedNumbersModel selectedNumbers)
        {
            return await crm.UpdateLineAsync(line.ToDto(), lineId);
        }

        public async Task<IEnumerable<PackageModel>> GetPackages()
        {
            try
            {
                var packages = await crm.GetPackagesAsync();
                List<PackageModel> list = packages.Select(p => p.ToModel()).ToList();
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}