using Framework.Application;
using Sun.Application.Contaracts.Shipper;
using Sun.Domain.ShipperAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Application
{
    public class ShipperApplication : IShipperApplication
    {
        private readonly IShipperRepository _repo;

        public ShipperApplication(IShipperRepository repo)
        {
            _repo = repo;
        }

        public OperationResult Create(ShipperCreateModel command)
        {
            var op = new OperationResult();
            if (command == null || string.IsNullOrWhiteSpace(command.Name) || string.IsNullOrWhiteSpace(command.Phonenumber))
            {
                return op.Failed(ApplicationMessages.NullOrEmptyData);
            }
            var shipper = new Shipper(command.Name, command.Phonenumber, command.Description);
            _repo.Create(shipper);
            _repo.SaveChanges();
            return op.Succedded();
        }

        public OperationResult Edit(ShipperEditModel command)
        {
            var op = new OperationResult();
            var flag = _repo.Get(command.Id);
            if (flag == null)
            {
                return op.Failed(ApplicationMessages.RecordNotFound);
            }

            flag.Edit(command.Name, command.Phonenumber, command.Description);
            _repo.SaveChanges();
            return op.Succedded();
        }

        public List<ShipperViewModel> GetAll()
        {
            return _repo.GetAll();
        }

        public ShipperEditModel GetDeatails(long id)
        {
            return _repo.GetDetailes(id);
        }

        public List<ShipperViewModel> Search(ShipperSearchModel command)
        {
            return _repo.Search(command);
        }
    }
}
