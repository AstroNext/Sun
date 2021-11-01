using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Role;
using Sun.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SunContext _context;

        public RoleRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Role command)
        {
            _context.Roles.Add(command);
        }

        public bool Exist(string name)
        {
            return _context.Roles.Any(x => x.Name == name);
        }

        public List<RoleViewModel> GetAll()
        {
            return _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().ToList();
        }

        public RoleEditModel GetDetails(long id)
        {
            return _context.Roles.Select(x => new RoleEditModel { Name = x.Name, Id = x.Id }).FirstOrDefault(x => x.Id == id);
        }

        public Role GetRole(long id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<RoleViewModel> Search(string name)
        {
            var query = _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            return query.OrderBy(x => x.Id).ToList();
        }
    }
}
