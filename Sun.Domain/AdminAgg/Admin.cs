using Framework.Application.Domain;
using Sun.Domain.ContactAgg;
using Sun.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.AdminAgg
{
    public class Admin : EntityBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public bool CanLogin { get; set; }
        public bool IsBlock { get; set; }

        public Admin(string name, string username, string password, string phonenumber, long roleId)
        {
            Name = name;
            Username = username;
            Password = password;
            Phonenumber = phonenumber;
            RoleId = roleId;
            CanLogin = true;
            IsBlock = false;
        }

        public void Edit(string name, string username, string phonenumber, long roleId)
        {
            Name = name;
            Username = username;
            Phonenumber = phonenumber;
            RoleId = roleId;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void Block()
        {
            IsBlock = true;
        }

        public void Unblock()
        {
            IsBlock = false;
        }

        public void CloseLogin()
        {
            CanLogin = false;
        }

        public void OpenLogin()
        {
            CanLogin = true;
        }
    }
}
