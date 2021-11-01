using Framework.Application.Domain;
using Sun.Domain.CartAgg;
using Sun.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.CartItemAgg
{
    public class CartItem : EntityBase
    {
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long CartId { get; set; }
        public Cart Cart { get; set; }

        public CartItem(int count, double unitPrice, long productId, long cartId)
        {
            Count = count;
            UnitPrice = unitPrice;
            ProductId = productId;
            CartId = cartId;
        }

        public void Edit(int count, double unitPrice, long productId)
        {
            Count = count;
            UnitPrice = unitPrice;
            ProductId = productId;
        }

        public void IncreaseUnitCount(int count)
        {
            Count += count;
        }

        public void DecreaseUnitCount(int count)
        {
            Count -= count;
        }
    }
}
