using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Domain.ProductBrandAgg;
using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SunContext _context;

        public BrandRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Brand productBrand)
        {
            _context.Brands.Add(productBrand);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return _context.Brands.Any(x => x.Name == name);
        }

        public Brand Get(long id)
        {
            return _context.Brands.FirstOrDefault(x => x.Id == id);
        }

        public List<BrandViewModel> GetAll()
        {
            return _context.Brands.Select(x => new BrandViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }

        public BrandEditModel GetDetails(long id)
        {
            return _context.Brands.Select(x => new BrandEditModel { Id = x.Id, Name = x.Name }).SingleOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts(long id)
        {
            return _context.Products
                .Where(x => x.BrandId == id)
               .Include(x => x.Brand)
               .Include(x => x.Category)
               .Include(x => x.Unit)
               .Select(x => new ProductViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   UnitPrice = x.UnitPrice,
                   IsRemoved = x.IsRemoved,
                   CreationDate = x.CreationDate.ToFarsi(),
                   Category = x.Category.Name,
                   Brand = x.Brand.Name,
                   Unit = x.Unit.Name

               }).AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<BrandViewModel> Search(string Name)
        {
            var query = _context.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(x => x.Name.Contains(Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
