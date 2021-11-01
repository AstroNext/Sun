using Framework.Application;
using Framework.Application.Auth;
using Framework.Application.Password;
using Sun.Application.Contaracts.Admin;
using Sun.Domain.AdminAgg;
using System.Collections.Generic;

namespace Sun.Application
{
    public class AdminApplication : IAdminApplication
    {
        private readonly IAdminRepository _repo;
        private readonly IPasswordHasher _hasher;
        private readonly IAuthHelper _authHelper;

        public AdminApplication(IAdminRepository repo, IPasswordHasher hasher, IAuthHelper authHelper)
        {
            _repo = repo;
            _hasher = hasher;
            _authHelper = authHelper;
        }
        public void Block(long id)
        {
            var admin = _repo.Get(id);

            if (admin == null)
            {
                return;
            }

            admin.Block();
            _repo.SaveChanges();
        }

        public void CloseLogin(long id)
        {
            var admin = _repo.Get(id);

            if (admin == null)
            {
                return;
            }

            admin.CloseLogin();
            _repo.SaveChanges();
        }

        public void Create(AdminCreateModel createAdmin)
        {
            if (_repo.Exist(createAdmin.Name))
            {
                return;
            }

            var admin = new Admin(createAdmin.Name, createAdmin.Username, _hasher.Hash(createAdmin.Password), createAdmin.Phonenumber, createAdmin.RoleId);

            _repo.Create(admin);
            _repo.SaveChanges();
        }

        public OperationResult Edit(AdminEditModel command)
        {
            var op = new OperationResult();
            var admin = _repo.Get(command.Id);

            if (admin == null)
            {
                return op.Failed(ApplicationMessages.RecordNotFound);
            }

            admin.Edit(command.Name, command.Username, command.Phonenumber, command.RoleId);
            _repo.SaveChanges();
            return op.Succedded();
        }

        public AdminViewModel GetAdminInfo(long id)
        {
            return _repo.GetAdmin(id);
        }

        public OperationResult Login(AdminLoginModel command)
        {
            var opration = new OperationResult();
            var account = _repo.GetByUsername(command.Username);

            if (account == null)
            {
                return opration.Failed(ApplicationMessages.WrongUserPass);
            }
            if (account.IsBlock || !account.CanLogin)
            {
                return opration.Failed(ApplicationMessages.YourAccountIsBlock);
            }
            var hashRes = _hasher.Hash(command.Password);
            var res = account.Password == hashRes;

            if (!res)
            {
                return opration.Failed(ApplicationMessages.WrongUserPass);
            }

            var auth = new AuthViewModel(account.Id, account.RoleId, account.Name, account.Username, account.Phonenumber, new List<int>{ });
            _authHelper.Signin(auth);
            return opration.Succedded();
        }

        public OperationResult Logout()
        {
            _authHelper.SignOut();
            return new OperationResult().Succedded();
        }

        public void OpenLogin(long id)
        {
            var admin = _repo.Get(id);

            if (admin == null)
            {
                return;
            }

            admin.OpenLogin();
            _repo.SaveChanges();
        }

        public List<AdminViewModel> Search(AdminSearchModel searchModel)
        {
            return _repo.Search(searchModel);
        }

        public void Unblock(long id)
        {
            var admin = _repo.Get(id);

            if (admin == null)
            {
                return;
            }

            admin.Unblock();
            _repo.SaveChanges();
        }
    }
}
