using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Product;
using Sun.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SunContext _context;

        public ProductRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public bool Exist(string name, long categoryId, long brandId)
        {
            return _context.Products.Any(x => x.Name == name && x.CategoryId == categoryId && x.BrandId == brandId);
        }

        public Product Get(long id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public ProductEditModel GetDetails(long id)
        {
            return _context.Products.Select(x => new ProductEditModel 
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId,
                BrandId = x.BrandId,
                UnitId = x.UnitId
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            var query = _context.Products.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Unit).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi(),
                Category = x.Category.Name,
                Brand = x.Brand.Name,
                Unit = x.Unit.Name
            });

            if (command.remove == true)
            {
                query = query.Where(x => x.IsRemoved == true);
            }

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
