using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.Domain.CartAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Infrastructure.EFCore.Mapping
{
    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasOne(x => x.Contact).WithOne(x => x.Cart).HasForeignKey<Cart>(x => x.ContactId);
            builder.HasMany(x => x.Items).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
            builder.HasMany(x => x.Orders).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
        }
    }
}
