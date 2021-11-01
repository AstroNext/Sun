using Framework.Application.Domain;
using Sun.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ProductBrandAgg
{
    public class Brand : EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Brand(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
