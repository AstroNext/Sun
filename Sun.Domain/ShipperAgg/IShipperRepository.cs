using Framework.Application.Domain;
using Sun.Application.Contaracts.Shipper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ShipperAgg
{
    public interface IShipperRepository : IRepository<long, Shipper>
    {
        Shipper GetBy(string name);
        ShipperEditModel GetDetailes(long id);
        List<ShipperViewModel> GetAll();
        List<ShipperViewModel> Search(ShipperSearchModel command);
    }
}
