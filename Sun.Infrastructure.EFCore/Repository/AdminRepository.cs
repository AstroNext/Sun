using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Admin;
using Sun.Application.Contaracts.Role;
using Sun.Domain.AdminAgg;
using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SunContext _context;

        public AdminRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Admin admin)
        {
            _context.Admins.Add(admin);
        }

        public bool Exist(string name)
        {
            return _context.Admins.Any(x => x.Name == name);
        }

        public Admin Get(long id)
        {
            return _context.Admins.FirstOrDefault(x => x.Id == id);
        }

        public AdminViewModel GetAdmin(long id)
        {
            return _context.Admins.Include(x => x.Role).Select(x => new AdminViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Username = x.Username,
                Phonenumber = x.Phonenumber,
                RoleId = x.RoleId,
                CanLogin = x.CanLogin,
                IsBlock = x.IsBlock,
                JoinDate = x.CreationDate.ToFarsi(),
                Role = new RoleViewModel 
                {
                    Id = x.Role.Id,
                    Name = x.Role.Name
                }
            }).FirstOrDefault(x => x.Id == id);
        }

        public Admin GetByUsername(string name)
        {
            return _context.Admins.FirstOrDefault(x => x.Username == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<AdminViewModel> Search(AdminSearchModel name)
        {
            var query = _context.Admins.Include(x => x.Role).Select(x => new AdminViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Username = x.Username,
                Phonenumber = x.Phonenumber,
                RoleId= x.RoleId,
                CanLogin = x.CanLogin,
                IsBlock = x.IsBlock,
                JoinDate = x.CreationDate.ToFarsi(),
                Role = new RoleViewModel
                {
                    Id = x.Role.Id,
                    Name = x.Role.Name
                }
            });

            if (!string.IsNullOrWhiteSpace(name.Name))
            {
                query = query.Where(x => x.Name.Contains(name.Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
