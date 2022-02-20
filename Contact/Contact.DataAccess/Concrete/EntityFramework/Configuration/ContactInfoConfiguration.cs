using Contact.DataAccess.Constant;
using Contact.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(s => s.Info).HasMaxLength(150);
            builder.Property(s => s.InfoType).HasConversion(v => (short)v, v => (InfoType)v).IsRequired();
        }
    }
}
