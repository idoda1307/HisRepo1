using Client.CRMServiceReference;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public interface ILineService
    {
        Task<IEnumerable<ClientModel>> GetClients();
        Task<IEnumerable<LineModel>> GetLines(string clientId);
        Task<LineDto> AddLine(LineModel line, SelectedNumbersModel selectedNumbers);
        Task<bool> DeleteLine(LineModel line);
        Task<LineDto> UpdateLine(int lineId, LineModel line, SelectedNumbersModel selectedNumbers);
        Task<IEnumerable<PackageModel>> GetPackages();
    }
}
