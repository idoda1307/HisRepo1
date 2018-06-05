namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CellularCompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.CellularCompanyContext context)
        {
            context.ClientType.AddOrUpdate(t => t.TypeName,
new Models.ClientTypeEntity() { TypeName = "business", MinutePrice = 1, SMSPrice = 0.5 },
new Models.ClientTypeEntity() { TypeName = "Private", MinutePrice = 1.5, SMSPrice = 1 },
new Models.ClientTypeEntity() { TypeName = "VIP", MinutePrice = 0.5, SMSPrice = 0.25 }
);
            context.Packages.AddOrUpdate(p => p.PackageName,
                new PackageEntity()
                {
                    PackageId = 1,
                    PackageName = "All Includes",
                    PackageTotalPrice = 100,
                    PackageIncludes =
                        new PackageIncludesEntity()
                        {
                            IncludeName = "cheap most called number calls",
                            DiscountPrecentage = 20,
                            MostCalledNumber = true,
                            MaxMinute = 60,
                            FixedPrice = 10
                        }
                },
                new PackageEntity()
                {
                    PackageId = 2,
                    PackageName = "Family Extra",
                    PackageTotalPrice = 40,
                    PackageIncludes =
                        new PackageIncludesEntity()
                        {
                            InsideFamilyCalls = true,
                            DiscountPrecentage = 30,
                            IncludeName = "cheapier family talks",
                            MaxMinute = 180,
                            FixedPrice = 15

                        }
                },
            new PackageEntity()
            {
                PackageId = 3,
                PackageName = "Unlimited",
                PackageTotalPrice = 120,
                PackageIncludes =
                        new PackageIncludesEntity()
                        {
                            IncludeName = "unlimited talks",
                            MaxMinute = int.MaxValue,
                            FixedPrice = 80
                        }
            });
        }
    }
}
