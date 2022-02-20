using Contact.DataAccess.Entities;
using Core.Utilities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contact.DataAccess.Concrete.EntityFramework.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext()
        {

        }
        public ContactDbContext(DbContextOptions<ContactDbContext> option):base(option)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Report> Report { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = ConfigurationHelper.GetConfig("dalsettings");
                var conStr = configuration.GetConnectionString("Default");
                optionsBuilder.UseNpgsql(conStr);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>().HasKey(h => h.PersonUUID);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(e => e.Person)
                .WithMany(e => e.ContactInfos)
                .HasForeignKey(e => e.PersonUUID);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
