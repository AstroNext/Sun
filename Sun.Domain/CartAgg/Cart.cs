using Framework.Application.Domain;
using Sun.Domain.CartItemAgg;
using Sun.Domain.ContactAgg;
using Sun.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.CartAgg
{
    public class Cart : EntityBase
    {
        public long ContactId { get; set; }
        public Contact Contact { get; set; }
        public List<CartItem> Items { get; set; }
        public List<Order> Orders { get; set; }

        public Cart(long contactId)
        {
            ContactId = contactId;
            Items = new List<CartItem>();
            Orders = new List<Order>();
        }
        public void AddCartItem(CartItem item)
        {
            Items.Add(item);
        }
        public void RemoveCartItem(CartItem item)
        {
            Items.Remove(item);
        }
    }
}
