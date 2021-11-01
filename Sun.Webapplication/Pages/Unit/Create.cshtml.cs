using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Unit
{
    public class CreateModel : PageModel
    {
        private readonly IUnitApplication _repo;
        [TempData]
        public string Message { get; set; }
        public CreateModel(IUnitApplication repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(UnitCreateModel command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                Message = "نام خالی است !";
                return null;
            }
            _repo.Create(command);
            return RedirectToPage("./index");
        }
    }
}
