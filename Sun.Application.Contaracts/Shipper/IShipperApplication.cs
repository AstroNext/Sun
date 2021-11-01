using Framework.Application;
using System.Collections.Generic;

namespace Sun.Application.Contaracts.Shipper
{
    public interface IShipperApplication
    {
        OperationResult Edit(ShipperEditModel command);
        OperationResult Create(ShipperCreateModel command);
        ShipperEditModel GetDeatails(long id);
        List<ShipperViewModel> Search(ShipperSearchModel command);
        List<ShipperViewModel> GetAll();
    }
}
