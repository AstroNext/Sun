using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.Application.Contaracts.Admin;
using Sun.Application.Contaracts.Role;

namespace Sun.Webapplication.Pages.Admin
{
    public class EditModel : PageModel
    {
        public string Message { get; set; }
        public SelectList PremissionList;
        private readonly IAdminApplication _repo;
        private readonly IRoleApplication _roleRepo;
        public AdminViewModel Admin;

        public EditModel(IAdminApplication repo, IRoleApplication roleRepo)
        {
            _repo = repo;
            _roleRepo = roleRepo;
        }

        public void OnGet(long id)
        {
            PremissionList = new SelectList(_roleRepo.GetAll(), "Id", "Name");
            Admin = _repo.GetAdminInfo(id);
        }

        public RedirectToPageResult OnPost(AdminEditModel adminEdit)
        {
            var op = _repo.Edit(adminEdit);
            if (op.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = op.Message;
            return null;
        }
    }
}
