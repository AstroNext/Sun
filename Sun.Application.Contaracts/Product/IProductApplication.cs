using System.Collections.Generic;

namespace Sun.Application.Contaracts.Product
{
    public interface IProductApplication
    {
        void Create(ProductCreateModel createProduct);
        void Edit(ProductEditModel editProduct);
        void Remove(int id);
        void Restore(int id);
        ProductEditModel GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
