using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface ILineRepository
    {
        Task<LineDto> AddLineEntity(LineDto line, SelectedNumbersDto selectedNumbers);
        Task<bool> DeleteLine(int lineId);
        Task<LineDto> UpdateLine(LineDto line, int lineId);
        //IEnumerable<LineDto> GetDestinationLines(int lineId);
        LineDto GetLine(int lineId);
        IEnumerable<string> GetLineSelectedNumbers(int lineId);
        PackageIncludesDto GetPackageIncludes(int packageIncludesId);
        LineDto GetLineByNumber(string number);
        IEnumerable<LineDto> GetLines();
        IEnumerable<LineDto> GetClientLines(string clientId);
    }
}
