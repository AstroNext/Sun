using Framework.Application.Domain;
using Sun.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.UnitAgg
{
    public class Unit : EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Unit(string name)
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
