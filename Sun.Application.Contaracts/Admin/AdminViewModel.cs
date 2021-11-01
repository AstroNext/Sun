using Sun.Application.Contaracts.Contact;
using Sun.Application.Contaracts.Role;

namespace Sun.Application.Contaracts.Admin
{
    public class AdminViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Phonenumber { get; set; }
        public bool CanLogin { get; set; }
        public bool IsBlock { get; set; }
        public long RoleId { get; set; }
        public RoleViewModel Role { get; set; }
        public string JoinDate { get; set; }
    }
}
