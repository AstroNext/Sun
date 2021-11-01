using Sun.Application.Contaracts.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.ProductCategory
{
    public interface ICategoryApplication
    {
        void Create(CategoryCreateModel command);
        void Edit(CategoryEditModel command);
        List<CategoryViewModel> Search(string name);
        CategoryEditModel GetDetail(long id);
        List<CategoryViewModel> GetAll();
        List<ProductViewModel> GetProducts(long id);
    }
}
