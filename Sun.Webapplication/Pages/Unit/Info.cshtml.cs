using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Unit
{
    public class InfoModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IUnitApplication _repo;

        public InfoModel(IUnitApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(long id)
        {
            ViewData.Add("unitName", _repo.GetDetail(id).Name);
            Products = _repo.GetProducts(id);
        }
    }
}
