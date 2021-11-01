using Framework.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.CartAgg
{
    interface ICartRepository : IRepository<long, Cart>
    {
    }
}
