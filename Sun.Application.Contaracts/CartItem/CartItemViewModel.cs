using Sun.Application.Contaracts.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application.Contaracts.CartItem
{
    public class CartItemViewModel
    {
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public int ProductCount { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
