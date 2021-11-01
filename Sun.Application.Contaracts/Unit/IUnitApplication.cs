using Sun.Application.Contaracts.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.Unit
{
    public interface IUnitApplication
    {
        void Create(UnitCreateModel command);
        void Edit(UnitEditModel command);
        List<UnitViewModel> Search(UnitSearchModel name);
        UnitEditModel GetDetail(long id);
        List<UnitViewModel> GetAll();
        List<ProductViewModel> GetProducts(long command);
    }
}
