using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Dtos;
using System.Diagnostics;
using Common.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        public async Task<PackageDto> CreatePackage(PackageDto package,PackageIncludesDto packageIncludes)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (package != null)
                    {
                        PackageEntity entity = new PackageEntity()
                        {
                            PackageName=package.PackageName,
                            PackageTotalPrice=package.PackageTotalPrice,
                        };
                        db.PackageIncludes.Add(packageIncludes.ToModel());
                        await db.SaveChangesAsync();
                        return entity.ToDto();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public async Task<PackageDto> UpdatePackage(PackageDto package, int packageId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    if (package != null && packageId != 0)
                    {
                        package.PackageId = packageId;
                        PackageEntity entity = package.ToModel();
                        db.Packages.Attach(entity);
                        foreach (var propName in db.Entry(entity).CurrentValues.PropertyNames)
                        {
                            if (propName != nameof(entity.PackageId))
                            {
                                db.Entry(entity).Property(propName).IsModified = true;
                            }
                        }
                        await db.SaveChangesAsync();
                        return entity.ToDto();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public PackageDto GetPackage(int id)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    return db.Packages.FirstOrDefault(p => p.PackageId == id).ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public IEnumerable<PackageDto> GetPackages()
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var a = db.Packages.ToList();
                    return a.Select(p => p.ToDto());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public PackageIncludesDto GetPackageIncludes(int packageId)
        {
            using (CellularCompanyContext db = new CellularCompanyContext())
            {
                try
                {
                    var a = db.PackageIncludes.Where(p=>p.PackageIncludesId==packageId).FirstOrDefault();
                    return a.ToDto();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
        }


    }
}
