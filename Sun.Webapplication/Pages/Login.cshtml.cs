using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Admin;

namespace Sun.Webapplication.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }
        private readonly IAdminApplication _repo;

        public LoginModel(IAdminApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(){}

        public IActionResult OnPost(AdminLoginModel command)
        {
            var res = _repo.Login(command);
            if (res.IsSuccedded)
                return RedirectToPage("/Index");

            ErrorMessage = res.Message;
            return null;
        }

        public RedirectToPageResult OnGetLogout()
        {
            _repo.Logout();
            return RedirectToPage("/Login");
        }
    }
}
