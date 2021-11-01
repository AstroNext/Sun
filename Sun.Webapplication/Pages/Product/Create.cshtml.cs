using Framework.Application.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList ProductCategorys;
        public SelectList ProductBrands;
        public SelectList ProductUnits;

        private readonly IProductApplication _repo;
        private readonly ICategoryApplication _categoryRepo;
        private readonly IBrandApplication _brandRepo;
        private readonly IUnitApplication _unitRepo;

        public CreateModel(IProductApplication productApplication, ICategoryApplication categoryApplication, IBrandApplication productBrand, IUnitApplication unitRepo)
        {
            _repo = productApplication;
            _categoryRepo = categoryApplication;
            _brandRepo = productBrand;
            _unitRepo = unitRepo;
        }

        public void OnGet()
        {
            ProductCategorys = new SelectList(_categoryRepo.GetAll(), "Id", "Name");
            ProductBrands = new SelectList(_brandRepo.GetAll(), "Id", "Name");
            ProductUnits = new SelectList(_unitRepo.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(ProductCreateModel command)
        {
            _repo.Create(command);
            return RedirectToPage("./index");
        }
    }
}
