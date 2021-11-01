using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Unit
{
    public class EditModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UnitEditModel Command;
        private readonly IUnitApplication _repo;

        public EditModel(IUnitApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Command = _repo.GetDetail(id);
        }

        public RedirectToPageResult OnPost(UnitEditModel command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                Message = "نام خالی است !";
                return null;
            }
            _repo.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
