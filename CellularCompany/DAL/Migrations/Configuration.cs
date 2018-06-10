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
            context.Clients.AddOrUpdate(c => c.ClientId,
    new ClientEntity() { ClientId = "1", FirstName = "Ido", LastName = "Dahan", Address = "shoham", ClientTypeId = 1, ContactNumber = "1", CallsToCenter = 1 },
    new ClientEntity() { ClientId = "2", FirstName = "Shimon", LastName = "Ben Haim", Address = "tel aviv", ClientTypeId = 2, ContactNumber = "2", CallsToCenter = 3 },
    new ClientEntity() { ClientId = "3", FirstName = "Shelly", LastName = "Aharoni", Address = "tel aviv", ClientTypeId = 2, ContactNumber = "3", CallsToCenter = 8 },
    new ClientEntity() { ClientId = "4", FirstName = "Shay", LastName = "Melamud", Address = "petach tikwa", ClientTypeId = 3, ContactNumber = "4", CallsToCenter = 4 },
    new ClientEntity() { ClientId = "5", FirstName = "Golan", LastName = "Soffer", Address = "kfar yona", ClientTypeId = 1, ContactNumber = "5", CallsToCenter = 10 });

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
            context.Lines.AddOrUpdate(l => l.Number,
                new LineEntity() { ClientId = "1", Number = "1", PackageId = 1, Status = LineStatus.available },
                new LineEntity() { ClientId = "1", Number = "6", PackageId = 3, Status = LineStatus.available },
                new LineEntity() { ClientId = "1", Number = "7", PackageId = 1, Status = LineStatus.available },
                new LineEntity() { ClientId = "2", Number = "2", PackageId = 2, Status = LineStatus.available },
                new LineEntity() { ClientId = "2", Number = "8", PackageId = 3, Status = LineStatus.available },
                new LineEntity() { ClientId = "3", Number = "3", PackageId = 2, Status = LineStatus.available },
                new LineEntity() { ClientId = "3", Number = "9", PackageId = 1, Status = LineStatus.available },
                new LineEntity() { ClientId = "4", Number = "4", PackageId = 1, Status = LineStatus.available },
                new LineEntity() { ClientId = "5", Number = "5", PackageId = 3, Status = LineStatus.available });
            context.Calls.AddOrUpdate(c => c.CallId,
                new CallsEntity { DestinationNumber = "2", Duration = 25, ExternalPrice = 3, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "3", Duration = 30, ExternalPrice = 2.5, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "4", Duration = 32, ExternalPrice = 2, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "5", Duration = 35, ExternalPrice = 3.5, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "6", Duration = 25, ExternalPrice = 3, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "6", Duration = 15, ExternalPrice = 3, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "6", Duration = 20, ExternalPrice = 3, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "6", Duration = 25, ExternalPrice = 3, LineId = 1, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "1", Duration = 45, ExternalPrice = 5, LineId = 2, Time = DateTime.Now },
                new CallsEntity { DestinationNumber = "1", Duration = 25, ExternalPrice = 3, LineId = 2, Time = DateTime.Now });
            context.SMS.AddOrUpdate(s => s.SMSId,
                new SMSEntity() { DestinationNumber = "2", ExternalPrice = 1, LineId = 1, Time = DateTime.Now },
                new SMSEntity() { DestinationNumber = "3", ExternalPrice = 1.25, LineId = 1, Time = DateTime.Now },
                new SMSEntity() { DestinationNumber = "4", ExternalPrice = 0.75, LineId = 1, Time = DateTime.Now },
                new SMSEntity() { DestinationNumber = "5", ExternalPrice = 0.5, LineId = 1, Time = DateTime.Now },
                new SMSEntity() { DestinationNumber = "2", ExternalPrice = 1, LineId = 1, Time = DateTime.Now });
        }
    }
}