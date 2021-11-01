using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Category
{
    public class IndexModel : PageModel
    {
        public List<CategoryViewModel> productCategories;
        private readonly ICategoryApplication _repo;

        public IndexModel(ICategoryApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(CategorySearchModel command)
        {
            productCategories = _repo.Search(command.Name);
        }
    }
}
