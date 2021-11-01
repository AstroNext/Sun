using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

namespace Sun.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepositroy _repo;

        public CategoryApplication(ICategoryRepositroy productCategoryRepository)
        {
            _repo = productCategoryRepository;
        }

        public void Create(CategoryCreateModel command)
        {
            if (_repo.Exists(command.Name))
            {
                return;
            }
            var productCategory = new Category(command.Name);
            _repo.Create(productCategory);
            _repo.SaveChanges();
        }

        public void Edit(CategoryEditModel command)
        {
            var productCategory = _repo.Get(command.Id);

            if (productCategory == null)
            {
                return;
            }
            productCategory.Edit(command.Name);
            _repo.SaveChanges();
        }

        public List<CategoryViewModel> GetAll()
        {
            return _repo.GetAll();
        }

        public CategoryEditModel GetDetail(long id)
        {
            return _repo.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts(long id)
        {
            return _repo.GetProducts(id);
        }

        public List<CategoryViewModel> Search(string name)
        {
            return _repo.Search(name);
        }
    }
}
