using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BLInterfaces.RepositoriesManagersInterfaces
{
    public interface IPackageManager
    {
        Task<PackageDto> AddPackageDto(PackageDto dto, PackageIncludesDto packageIncludes);
        Task<PackageDto> UpdatePackageDto(PackageDto dto, int packageId);
        PackageDto GetPackageDto(int packageId);
        IEnumerable<PackageDto> GetPackageDtos();
        PackageIncludesDto GetPackageIncludes(int packageId);
    }
}
