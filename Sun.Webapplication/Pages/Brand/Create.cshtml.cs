using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Brand
{
    public class CreateModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IBrandApplication _repo;
        public CreateModel(IBrandApplication repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(BrandCreateModel command)
        {
            if (string.IsNullOrEmpty(command.Name))
            {
                Message = "نام خالی است !";
                return null;
            }

            _repo.Create(command);
            return RedirectToPage("./index");
        }
    }
}
