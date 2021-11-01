using Framework.Application.Domain;
using Sun.Domain.AdminAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Admin> Admins { get; set; }
        public Role(string name)
        {
            Name = name;
            Admins = new List<Admin>();
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }
}
