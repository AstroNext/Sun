using Framework.Application.Domain;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.Unit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sun.Domain.UnitAgg
{
    public interface IUnitRepository
    {
        void SaveChanges();
        bool Exists(string command);
        void Create(Unit command);
        Unit Get(long id);
        List<UnitViewModel> Search(UnitSearchModel command);
        UnitEditModel GetDetails(long id);
        List<UnitViewModel> GetAll();
        List<ProductViewModel> GetProducts(long command);
    }
}
