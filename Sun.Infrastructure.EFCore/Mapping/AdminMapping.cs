using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.Domain.AdminAgg;
using Sun.Domain.ContactAgg;

namespace Sun.Infrastructure.EFCore.Mapping
{
    public class AdminMapping : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.Role).WithMany(x => x.Admins).HasForeignKey(x => x.RoleId);
        }
    }
}
