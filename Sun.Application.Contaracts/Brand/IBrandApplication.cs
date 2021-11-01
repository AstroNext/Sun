using Sun.Application.Contaracts.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.ProductBrand
{
    public interface IBrandApplication
    {
        void Create(BrandCreateModel command);
        void Edit(BrandEditModel command);
        List<BrandViewModel> Search(string name);
        BrandEditModel GetDetail(long id);
        List<BrandViewModel> GetAll();
        List<ProductViewModel> GetProducts(long id);
    }
}
