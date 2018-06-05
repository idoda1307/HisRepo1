using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.RepositoryInterfaces
{
    public interface IPackageRepository
    {
        Task<PackageDto> CreatePackage(PackageDto package, PackageIncludesDto packageIncludes);
        Task<PackageDto> UpdatePackage(PackageDto package, int packageId);
        PackageDto GetPackage(int id);
        IEnumerable<PackageDto> GetPackages();
        PackageIncludesDto GetPackageIncludes(int packageId);
    }
}
