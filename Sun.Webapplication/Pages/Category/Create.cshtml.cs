using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryApplication _repo;

        public CreateModel(ICategoryApplication repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CategoryCreateModel command)
        {
            _repo.Create(command);
            return RedirectToPage("./index");
        }
    }
}
