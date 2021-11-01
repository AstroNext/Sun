using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.Domain.AdminAgg;
using Sun.Domain.ContactAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Infrastructure.EFCore.Mapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Contact).HasForeignKey(x => x.ContactId);
        }
    }
}
