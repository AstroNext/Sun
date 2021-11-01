using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sun.Application.Contaracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.Webapplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productRepo;

        public ProductController(IProductApplication productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("Products")]
        public string GetProducts()
        {
            return JsonConvert.SerializeObject(_productRepo.Search(new ProductSearchModel()));
        }
    }
}
