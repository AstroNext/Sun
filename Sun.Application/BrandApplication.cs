using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Domain.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly IBrandRepository _repo;

        public BrandApplication(IBrandRepository repo)
        {
            _repo = repo;
        }

        public void Create(BrandCreateModel command)
        {
            if (_repo.Exists(command.Name))
            {
                return;
            }

            var brand = new Brand(command.Name);
            _repo.Create(brand);
            _repo.SaveChanges();
        }

        public void Edit(BrandEditModel command)
        {
            var brand = _repo.Get(command.Id);

            if (brand == null)
            {
                return;
            }

            brand.Edit(command.Name);
            _repo.SaveChanges();
        }

        public List<BrandViewModel> GetAll()
        {
            return _repo.GetAll();
        }

        public BrandEditModel GetDetail(long id)
        {
            return _repo.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts(long id)
        {
            return _repo.GetProducts(id);
        }

        public List<BrandViewModel> Search(string name)
        {
            return _repo.Search(name);
        }
    }
}
