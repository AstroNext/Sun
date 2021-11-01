using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Application.Contaracts.Unit;

namespace Sun.Webapplication.Pages.Unit
{
    public class IndexModel : PageModel
    {
        public List<UnitViewModel> productUnits;
        private readonly IUnitApplication _repo;

        public IndexModel(IUnitApplication repo)
        {
            _repo = repo;
        }

        public void OnGet(UnitSearchModel command)
        {
            productUnits = _repo.Search(command);
        }
    }
}
