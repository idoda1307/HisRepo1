using Autofac;
using Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces;
using Common.Interfaces.RepositoryInterfaces;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.RepositoriesManagers
{
    public class LineManager : ILineManager
    {
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LineRepository>()
                    .As<ILineRepository>()
                    .SingleInstance();
            return builder.Build();
        }

        public async Task<LineDto> AddLine(LineDto line, SelectedNumbersDto selectedNumbers)
        {
            return await GetContainer().Resolve<ILineRepository>().AddLineEntity(line, selectedNumbers);
        }

        public async Task<bool> RemoveLineDto(int lineId)
        {
            return await GetContainer().Resolve<ILineRepository>().DeleteLine(lineId);
        }

        public async Task<LineDto> UpdateLineDto(LineDto dto, int lineId)
        {
            return await GetContainer().Resolve<ILineRepository>().UpdateLine(dto, lineId);
        }

        public LineDto GetLineDto(int lineId)
        {
            return GetContainer().Resolve<ILineRepository>().GetLine(lineId);
        }

        public IEnumerable<LineDto> GetLineDtos()
        {
            return GetContainer().Resolve<ILineRepository>().GetLines();
        }

        public IEnumerable<string> GetSelectedNumbersByLine(int lineId)
        {
            return GetContainer().Resolve<ILineRepository>().GetLineSelectedNumbers(lineId);
        }

        public PackageIncludesDto GetPackageIncludes(int packageIncludesId)
        {
            return GetContainer().Resolve<ILineRepository>().GetPackageIncludes(packageIncludesId);
        }

        public LineDto GetLineByNumber(string number)
        {
            return GetContainer().Resolve<ILineRepository>().GetLineByNumber(number);
        }

        public IEnumerable<LineDto> GetDestinationLines(int lineId)
        {
            return GetContainer().Resolve<ILineRepository>().GetLines().Where(l => l.LineId != lineId);
        }

        public IEnumerable<LineDto> GetClientLines(string clientId)
        {
            var a= GetContainer().Resolve<ILineRepository>().GetClientLines(clientId);
            return a;
        }
    }
}
