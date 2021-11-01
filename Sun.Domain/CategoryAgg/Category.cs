using Framework.Application.Domain;
using Sun.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ProductCategoryAgg
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Category(string name)
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
