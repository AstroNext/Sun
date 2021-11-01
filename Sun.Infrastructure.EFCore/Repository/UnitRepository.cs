using Framework.Application;
using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.Unit;
using Sun.Domain.UnitAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly SunContext _context;

        public UnitRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Unit command)
        {
            _context.Units.Add(command);
        }

        public bool Exists(string command)
        {
            return _context.Units.Any(x => x.Name == command);
        }

        public Unit Get(long id)
        {
            return _context.Units.FirstOrDefault(x => x.Id == id);
        }

        public List<UnitViewModel> GetAll()
        {
            return _context.Units.Select(x => new UnitViewModel { Id = x.Id, Name = x.Name, CreationDate = x.CreationDate.ToFarsi() }).ToList();
        }

        public UnitEditModel GetDetails(long id)
        {
            return _context.Units.Select(x => new UnitEditModel { Id = x.Id, Name = x.Name }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts(long command)
        {
            return _context.Products
                .Where(x => x.UnitId == command)
               .Include(x => x.Brand)
               .Include(x => x.Category)
               .Include(x => x.Unit)
               .Select(x => new ProductViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   UnitPrice = x.UnitPrice,
                   IsRemoved = x.IsRemoved,
                   CreationDate = x.CreationDate.ToFarsi(),
                   Category = x.Category.Name,
                   Brand = x.Brand.Name,
                   Unit = x.Unit.Name

               }).AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<UnitViewModel> Search(UnitSearchModel command)
        {
            var query = _context.Units.Select(x => new UnitViewModel { Id = x.Id, Name = x.Name, CreationDate = x.CreationDate.ToFarsi() });

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
