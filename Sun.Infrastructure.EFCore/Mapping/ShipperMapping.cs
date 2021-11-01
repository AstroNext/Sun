using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.Domain.ShipperAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Infrastructure.EFCore.Mapping
{
    public class ShipperMapping : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Phonenumber).HasMaxLength(255).IsRequired();
        }
    }
}
