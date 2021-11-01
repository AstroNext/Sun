using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;

namespace Sun.Webapplication.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> products;
        private readonly IProductApplication _repo;

        public IndexModel(IProductApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(ProductSearchModel productSearch)
        {
            products = _repo.Search(productSearch);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _repo.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetResotre(int id)
        {
            _repo.Restore(id);
            return RedirectToPage("./Index");
        }
        public void OnGetRemoved(ProductSearchModel searchModel)
        {
            searchModel.remove = true;
            products = _repo.Search(searchModel);
        }
    }
}
