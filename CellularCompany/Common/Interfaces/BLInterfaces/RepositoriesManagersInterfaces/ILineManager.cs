using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces
{
    public interface ILineManager
    {
        Task<LineDto> AddLine(LineDto line, SelectedNumbersDto selectedNumbers);
        Task<bool> RemoveLineDto(int lineId);
        Task<LineDto> UpdateLineDto(LineDto dto, int lineId);
        LineDto GetLineDto(int lineId);
        IEnumerable<LineDto> GetLineDtos();
        IEnumerable<LineDto> GetDestinationLines(int lineId);
        IEnumerable<string> GetSelectedNumbersByLine(int lineId);
        PackageIncludesDto GetPackageIncludes(int packageIncludesId);
        LineDto GetLineByNumber(string number);
        IEnumerable<LineDto> GetClientLines(string clientId);
        //bool CheckIfNumberAlreadyExist(string number);
        //Task<LineDto> AddLineDto(LineDto line);
    }
}