using Framework.Application;
using Framework.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Shipper;
using Sun.Domain.ShipperAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class ShipperRepository : RepositoryBase<long, Shipper>, IShipperRepository
    {
        private readonly SunContext _context;
        public ShipperRepository(SunContext context) : base(context)
        {
            _context = context;
        }

        public List<ShipperViewModel> GetAll()
        {
            return _context.Shippers.Select(x => new ShipperViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Phonenumber = x.Phonenumber,
                Description = x.Description,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }

        public Shipper GetBy(string name)
        {
            return _context.Shippers.FirstOrDefault(x => x.Name == name);
        }

        public ShipperEditModel GetDetailes(long id)
        {
            return _context.Shippers.Select(x => new ShipperEditModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Phonenumber = x.Phonenumber
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ShipperViewModel> Search(ShipperSearchModel command)
        {
            var query = _context.Shippers.Select(x => new ShipperViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Phonenumber = x.Phonenumber,
                Description = x.Description,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
