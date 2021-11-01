using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ProductBrandAgg
{
    public interface IBrandRepository
    {
        void SaveChanges();
        bool Exists(string name);
        void Create(Brand productCategory);
        Brand Get(long id);
        List<BrandViewModel> Search(string Name);
        BrandEditModel GetDetails(long id);
        List<BrandViewModel> GetAll();
        List<ProductViewModel> GetProducts(long id);
    }
}
