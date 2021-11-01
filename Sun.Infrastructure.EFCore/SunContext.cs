using Microsoft.EntityFrameworkCore;
using Sun.Domain.AdminAgg;
using Sun.Domain.ContactAgg;
using Sun.Domain.ProductAgg;
using Sun.Domain.ProductBrandAgg;
using Sun.Domain.ProductCategoryAgg;
using Sun.Domain.RoleAgg;
using Sun.Domain.ShipperAgg;
using Sun.Domain.UnitAgg;
using Sun.Infrastructure.EFCore.Mapping;

namespace Sun.Infrastructure.EFCore
{
    public class SunContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        public SunContext(DbContextOptions<SunContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
