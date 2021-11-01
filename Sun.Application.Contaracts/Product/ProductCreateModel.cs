using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.Product
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public long UnitId { get; set; }
    }
}
