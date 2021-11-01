using Framework.Application.Domain;
using Sun.Domain.CartAgg;
using Sun.Domain.CartItemAgg;
using Sun.Domain.ContactAgg;
using Sun.Domain.PaymentAgg;
using Sun.Domain.ShipperAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public int Status { get; set; }
        public long ContactId { get; set; }
        public Contact Contact { get; set; }
        public long ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }

        public Order(int status, long cartId, long paymentId)
        {
            Status = status;
            CartId = cartId;
            PaymentId = paymentId;
        }
        public void SetShipper(long shipperId)
        {
            ShipperId = shipperId;
        }

        public void ChangeStatus(int stat)
        {
            Status = stat;
        }
    }
}
