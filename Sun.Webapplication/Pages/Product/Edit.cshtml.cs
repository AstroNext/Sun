using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Product
{
    public class EditModel : PageModel
    {
        public ProductEditModel Command;

        public SelectList ProductCategorys;
        public SelectList ProductBrands;
        public SelectList ProductUnits;

        private readonly IProductApplication _repo;
        private readonly ICategoryApplication _categoryRepo;
        private readonly IBrandApplication _brandRepo;
        private readonly IUnitApplication _unitRepo;

        public EditModel(IProductApplication repo, ICategoryApplication categoryRepo, IBrandApplication brandRepo, IUnitApplication unitRepo)
        {
            _repo = repo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _unitRepo = unitRepo;
        }

        public void OnGet(int id)
        {
            Command = _repo.GetDetails(id);
            ProductCategorys = new SelectList(_categoryRepo.GetAll(), "Id", "Name");
            ProductBrands = new SelectList(_brandRepo.GetAll(), "Id", "Name");
            ProductUnits = new SelectList(_unitRepo.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(ProductEditModel command)
        {
            _repo.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
