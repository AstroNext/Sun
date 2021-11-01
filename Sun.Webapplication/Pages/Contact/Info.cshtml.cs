using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Contact;

namespace Sun.Webapplication.Pages.Contact
{
    public class InfoModel : PageModel
    {
        public ContactViewModel Contact;
        private readonly IContactApplication _repo;

        public InfoModel(IContactApplication repo)
        {
            _repo = repo;
        }
        public void OnGet(int id)
        {
            Contact = _repo.GetContactInfo(id);
        }
    }
}
