using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Category
{
    public class InfoModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly ICategoryApplication _repo;
        public InfoModel(ICategoryApplication repo)
        {
            _repo = repo;
        }
        public void OnGet(long id)
        {
            ViewData.Add("catName", _repo.GetDetail((int)id).Name);
            Products = _repo.GetProducts(id);
        }
    }
}
