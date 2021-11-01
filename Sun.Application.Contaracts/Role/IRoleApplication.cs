using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.Role
{
    public interface IRoleApplication
    {
        void Edit(RoleEditModel command);
        void Create(RoleCreateModel command);
        List<RoleViewModel> GetAll();
        List<RoleViewModel> Search(string name);
        RoleEditModel GetDetails(int id);
    }
}
