namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using DAL.Models;
    public class CellularCompanyContext : DbContext
    {
        public CellularCompanyContext(): base("name=CellularCompanyContext"){}

        public DbSet<CallsEntity> Calls { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ClientTypeEntity> ClientType { get; set; }
        public DbSet<LineEntity> Lines { get; set; }
        public DbSet<PackageEntity> Packages { get; set; }
        public DbSet<PackageIncludesEntity> PackageIncludes { get; set; }
        public DbSet<PaymentEntity> Payment { get; set; }
        public DbSet<SelectedNumbersEntity> SelectedNumbers { get; set; }
        public DbSet<SMSEntity> SMS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
