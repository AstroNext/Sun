using Sun.Application.Contaracts.Product;
using Sun.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repo;

        public ProductApplication(IProductRepository repo)
        {
            _repo = repo;
        }

        public void Create(ProductCreateModel createProduct)
        {
            if (_repo.Exist(createProduct.Name, createProduct.CategoryId, createProduct.BrandId))
            {
                return;
            }

            var product = new Product(createProduct.Name, createProduct.UnitPrice, createProduct.CategoryId, createProduct.BrandId, createProduct.UnitId);
            _repo.Create(product);
            _repo.SaveChanges();
        }

        public void Edit(ProductEditModel editProduct)
        {
            var product = _repo.Get(editProduct.Id);

            if (product == null)
            {
                return;
            }

            product.Edit(editProduct.Name, editProduct.UnitPrice, editProduct.CategoryId, editProduct.BrandId, editProduct.UnitId);
            _repo.SaveChanges();
        }

        public ProductEditModel GetDetails(int id)
        {
            return _repo.GetDetails(id);
        }

        public void Remove(int id)
        {
            var product = _repo.Get(id);

            if (product == null)
            {
                return;
            }

            product.Remove();
            _repo.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = _repo.Get(id);

            if (product == null)
            {
                return;
            }

            product.Restore();
            _repo.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repo.Search(searchModel);
        }
    }
}
