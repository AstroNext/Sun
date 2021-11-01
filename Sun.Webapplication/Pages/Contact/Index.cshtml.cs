using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Contact;

namespace Sun.Webapplication.Pages.Contact
{
    public class IndexModel : PageModel
    {
        public List<ContactViewModel> contacts;
        public readonly IContactApplication _repo;

        public IndexModel(IContactApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(ContactSearchModel searchModel)
        {
            contacts = _repo.Search(searchModel);
        }

        public RedirectToPageResult OnGetBlock(int id)
        {
            _repo.Block(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetUnblock(int id)
        {
            _repo.UnBlock(id);
            return RedirectToPage("./Index");
        }
    }
}
