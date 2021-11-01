using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductBrand;

namespace Sun.Webapplication.Pages.Brand
{
    public class IndexModel : PageModel
    {
        public List<BrandViewModel> productBrands;
        private readonly IBrandApplication _repo;

        public IndexModel(IBrandApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(BrandSearchModel command)
        {
            productBrands = _repo.Search(command.Name);
        }
    }
}
