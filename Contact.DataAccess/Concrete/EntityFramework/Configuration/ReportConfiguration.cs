using Contact.DataAccess.Constant;
using Contact.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(e => e.UUID).ValueGeneratedOnAdd();
            builder.Property(e => e.RequestedDateTime).IsRequired();
            builder.Property(e => e.Path).HasMaxLength(1000);
            builder.Property(e => e.Status).HasConversion(v => (ushort)v, v => (ReportStatus)v).IsRequired();
        }
    }
}
