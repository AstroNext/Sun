using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductCategory;
using System.Collections.Generic;

namespace Sun.Domain.ProductCategoryAgg
{
    public interface ICategoryRepositroy
    {
        void SaveChanges();
        bool Exists(string name);
        void Create(Category productCategory);
        Category Get(long id);
        List<CategoryViewModel> Search(string Name);
        CategoryEditModel GetDetails(long id);
        List<CategoryViewModel> GetAll();

        List<ProductViewModel> GetProducts(long id);
    }
}
