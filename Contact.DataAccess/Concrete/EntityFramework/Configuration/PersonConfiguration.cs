using Contact.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Contact.DataAccess.Concrete.EntityFramework.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(s => s.UUID).ValueGeneratedOnAdd();
            builder.Property(p => p.Company).HasMaxLength(300);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(150);
        }
    }
}
