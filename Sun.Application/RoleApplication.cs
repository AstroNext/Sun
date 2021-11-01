using Sun.Application.Contaracts.Role;
using Sun.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _repo;

        public RoleApplication(IRoleRepository repo)
        {
            _repo = repo;
        }

        public void Create(RoleCreateModel command)
        {
            if (_repo.Exist(command.Name))
            {
                return;
            }
            var rl = new Role(command.Name);
            _repo.Create(rl);
            _repo.SaveChanges();
        }

        public void Edit(RoleEditModel command)
        {
            var role = _repo.GetRole(command.Id);

            if (role == null)
            {
                return;
            }

            role.Edit(command.Name);
            _repo.SaveChanges();
        }

        public List<RoleViewModel> GetAll()
        {
            return _repo.GetAll();
        }

        public RoleEditModel GetDetails(int id)
        {
            return _repo.GetDetails(id);
        }

        public List<RoleViewModel> Search(string name)
        {
            return _repo.Search(name);
        }
    }
}
