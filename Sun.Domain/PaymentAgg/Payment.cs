using Framework.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.PaymentAgg
{
    public class Payment : EntityBase
    {
        public long RefId { get; set; }
        public int Status { get; set; }
        public double PayAmount { get; set; }
        public string Description { get; set; }

        public Payment(long refId, int status, double payAmount, string description)
        {
            RefId = refId;
            Status = status;
            PayAmount = payAmount;
            Description = description;
        }
    }
}
