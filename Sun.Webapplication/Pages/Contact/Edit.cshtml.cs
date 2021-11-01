using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Contact;

namespace Sun.Webapplication.Pages.Contact
{
    public class EditModel : PageModel
    {
        public ContactEditModel Contact;
        private readonly IContactApplication _repo;

        public EditModel(IContactApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Contact = _repo.GetDetails(id);
        }

        public RedirectToPageResult OnPost(ContactEditModel contact)
        {
            _repo.Edit(contact);
            return RedirectToPage("./index");
        }
    }
}
