using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Contact;

namespace Sun.Webapplication.Pages.Contact
{
    public class CreateModel : PageModel
    {
        private readonly IContactApplication _repo;

        public CreateModel(IContactApplication repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(ContactCreateModel createContact)
        {
            _repo.Create(createContact);
            return RedirectToPage("./index");

        }
    }
}
