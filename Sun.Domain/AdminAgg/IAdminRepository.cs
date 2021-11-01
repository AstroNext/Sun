using Sun.Application.Contaracts.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.AdminAgg
{
    public interface IAdminRepository
    {
        void Create(Admin admin);
        bool Exist(string name);
        void SaveChanges();
        Admin Get(long id);
        AdminViewModel GetAdmin(long id);
        Admin GetByUsername(string name);
        List<AdminViewModel> Search(AdminSearchModel name);
    }
}
