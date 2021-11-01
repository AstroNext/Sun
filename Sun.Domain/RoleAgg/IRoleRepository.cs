using Sun.Application.Contaracts.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.RoleAgg
{
    public interface IRoleRepository
    {
        void Create(Role command);
        void SaveChanges();
        bool Exist(string name);
        List<RoleViewModel> GetAll();
        List<RoleViewModel> Search(string name);
        RoleEditModel GetDetails(long id);
        Role GetRole(long id);
    }
}
