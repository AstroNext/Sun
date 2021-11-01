using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Category
{
    public class EditModel : PageModel
    {
        public CategoryEditModel Command;
        private readonly ICategoryApplication _repo;

        public EditModel(ICategoryApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Command = _repo.GetDetail(id);
        }

        public RedirectToPageResult OnPost(CategoryEditModel command)
        {
            _repo.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
