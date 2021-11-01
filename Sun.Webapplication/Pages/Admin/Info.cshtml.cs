using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Admin;

namespace Sun.Webapplication.Pages.Admin
{
    public class InfoModel : PageModel
    {
        public AdminViewModel Admin;
        private readonly IAdminApplication _repo;

        public InfoModel(IAdminApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Admin = _repo.GetAdminInfo(id);
        }
    }
}
