using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.DataAccess.Entities;

namespace Report.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ContactReportConfiguration : IEntityTypeConfiguration<ContactReport>
    {
        public void Configure(EntityTypeBuilder<ContactReport> builder)
        {
            builder.Property(e => e.UUID).ValueGeneratedOnAdd();
            builder.Property(e => e.Status).HasConversion(v => (short)v, v => (ReportStatus)v).IsRequired();
        }
    }
}
