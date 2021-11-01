using Framework.Application.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Role;

namespace Sun.Webapplication.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _repo;

        public CreateModel(IRoleApplication repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(RoleCreateModel command)
        {
            _repo.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
