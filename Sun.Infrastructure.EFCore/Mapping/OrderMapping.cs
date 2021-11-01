using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Infrastructure.EFCore.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.CartId).IsRequired();
            builder.Property(x => x.ContactId).IsRequired();
            builder.Property(x => x.PaymentId).IsRequired();
            builder.Property(x => x.ShipperId).IsRequired();

            builder.HasOne(x => x.Contact).WithMany(x => x.Orders).HasForeignKey(x => x.ContactId);
        }
    }
}
