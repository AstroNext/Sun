using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.Unit;
using Sun.Domain.UnitAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application
{
    public class UnitApplication : IUnitApplication
    {
        private readonly IUnitRepository _repo;

        public UnitApplication(IUnitRepository repo)
        {
            _repo = repo;
        }

        public void Create(UnitCreateModel command)
        {
            if (_repo.Exists(command.Name))
            {
                return;
            }
            var unit = new Unit(command.Name);
            _repo.Create(unit);
            _repo.SaveChanges();
        }

        public void Edit(UnitEditModel command)
        {
            var unit = _repo.Get(command.Id);

            if (unit == null)
            {
                return;
            }

            unit.Edit(command.Name);
            _repo.SaveChanges();
        }

        public List<UnitViewModel> GetAll()
        {
            return _repo.GetAll();
        }

        public UnitEditModel GetDetail(long id)
        {
            return _repo.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts(long command)
        {
            return _repo.GetProducts(command);
        }

        public List<UnitViewModel> Search(UnitSearchModel name)
        {
            return _repo.Search(name);
        }
    }
}
