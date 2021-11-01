using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductBrand;

namespace Sun.Webapplication.Pages.Brand
{
    public class EditModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public BrandEditModel Command;
        private readonly IBrandApplication _repo;

        public EditModel(IBrandApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Command = _repo.GetDetail(id);
        }

        public RedirectToPageResult OnPost(BrandEditModel command)
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
