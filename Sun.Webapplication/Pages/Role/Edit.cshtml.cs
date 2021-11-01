using Framework.Application.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Role;

namespace Sun.Webapplication.Pages.Role
{
    public class EditModel : PageModel
    {
        public RoleEditModel Role;

        private readonly IRoleApplication _repo;

        public EditModel(IRoleApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Role = _repo.GetDetails(id);
        }

        public RedirectToPageResult OnPost(RoleEditModel command)
        {
            _repo.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
