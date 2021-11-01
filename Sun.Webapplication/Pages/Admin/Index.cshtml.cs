using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Admin;

namespace Sun.Webapplication.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public List<AdminViewModel> Admins;
        private readonly IAdminApplication _repo;

        public IndexModel(IAdminApplication repo)
        {
            _repo = repo;
        }
        public void OnGet(AdminSearchModel command)
        {
            Admins = _repo.Search(command);
        }
        public RedirectToPageResult OnGetBlock(int id)
        {
            _repo.Block(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetUnblock(int id)
        {
            _repo.Unblock(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetOpenLogin(int id)
        {
            _repo.OpenLogin(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetCloseLogin(int id)
        {
            _repo.CloseLogin(id);
            return RedirectToPage("./Index");
        }
    }
}
