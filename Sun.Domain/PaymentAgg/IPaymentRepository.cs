using Framework.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.PaymentAgg
{
    public interface IPaymentRepository : IRepository<long, Payment>
    {
    }
}
