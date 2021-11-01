using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Application.Contaracts.ProductCategory;

namespace Sun.Webapplication.Pages.Brand
{
    public class InfoModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IBrandApplication _repo;

        public InfoModel(IBrandApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(long id)
        {
            ViewData.Add("brandName", _repo.GetDetail(id).Name);
            Products = _repo.GetProducts(id);
        }
    }
}
