using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;
using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Domain.ProductCategoryAgg;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class CategoryRepository : ICategoryRepositroy
    {
        private readonly SunContext _Context;

        public CategoryRepository(SunContext context)
        {
            _Context = context;
        }

        public void Create(Category productCategory)
        {
            _Context.Categories.Add(productCategory);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return _Context.Categories.Any(x => x.Name == name);
        }

        public Category Get(long id)
        {
            return _Context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public List<CategoryViewModel> GetAll()
        {
            return _Context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }

        public CategoryEditModel GetDetails(long id)
        {
            return _Context.Categories.Select(x => new CategoryEditModel { Name = x.Name, Id = x.Id }).SingleOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts(long id)
        {
            return _Context.Products
                .Where(x => x.CategoryId == id)
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
            _Context.SaveChanges();
        }

        public List<CategoryViewModel> Search(string Name)
        {
            var query = _Context.Categories.Select(x => new CategoryViewModel
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
