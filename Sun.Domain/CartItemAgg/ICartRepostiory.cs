using Framework.Application.Domain;
using Sun.Application.Contaracts.CartItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.CartItemAgg
{
    public interface ICartRepostiory : IRepository<long, CartItem>
    {
        List<CartItemViewModel> GetBy(long id);
    }
}
