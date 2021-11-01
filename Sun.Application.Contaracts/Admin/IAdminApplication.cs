using Framework.Application;
using System.Collections.Generic;

namespace Sun.Application.Contaracts.Admin
{
    public interface IAdminApplication
    {
        void Create(AdminCreateModel createAdmin);
        void Block(long id);
        void Unblock(long id);
        void CloseLogin(long id);
        void OpenLogin(long id);
        OperationResult Edit(AdminEditModel command);
        AdminViewModel GetAdminInfo(long id);
        OperationResult Login(AdminLoginModel command);
        OperationResult Logout();
        List<AdminViewModel> Search(AdminSearchModel searchModel);

    }
}
