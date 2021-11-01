using System;
using System.Collections.Generic;
using System.Text;
using Framework.Application.Domain;

namespace Sun.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long, Order>
    {
    }
}
