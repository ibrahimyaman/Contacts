using Core.Utilities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Report.DataAccess.Entities;

namespace Report.DataAccess.Concrete.EntityFramework.Context
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext()
        {

        }
        public DbSet<ContactReport> ContactReport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = ConfigurationHelper.GetConfig();
                var conStr = configuration.GetConnectionString("Default");
                optionsBuilder.UseNpgsql(conStr);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
