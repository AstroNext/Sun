using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.Admin
{
    public class AdminEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Phonenumber { get; set; }
        public long RoleId { get; set; }
    }
}
