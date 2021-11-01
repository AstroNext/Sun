using Sun.Application.Contaracts.Product;
using System.Collections.Generic;

namespace Sun.Domain.ProductAgg
{
    public interface IProductRepository
    {
        void Create(Product product);
        void SaveChanges();
        ProductEditModel GetDetails(long id);
        Product Get(long id);
        bool Exist(string name, long categoryId, long brandId);
        List<ProductViewModel> Search(ProductSearchModel command);
    }
}
