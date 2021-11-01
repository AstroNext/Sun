using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Role;
using Framework.Application.Infrastructure;

namespace Sun.Webapplication.Pages.Role
{
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles;

        private readonly IRoleApplication _repo;

        public IndexModel(IRoleApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(RoleSearchModel command)
        {
            Roles = _repo.Search(command.Name);
        }
    }
}
