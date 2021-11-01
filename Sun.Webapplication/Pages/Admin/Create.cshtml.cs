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
    public class CreateModel : PageModel
    {
        public SelectList PremissionList;
        private readonly IAdminApplication _repo;
        private readonly IRoleApplication _roleRepo;

        public CreateModel(IAdminApplication repo, IRoleApplication roleRepo)
        {
            _repo = repo;
            _roleRepo = roleRepo;
        }

        public void OnGet()
        {
            PremissionList = new SelectList(_roleRepo.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(AdminCreateModel command)
        {
            _repo.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
