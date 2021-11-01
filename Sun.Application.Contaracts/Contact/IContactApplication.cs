using System.Collections.Generic;

namespace Sun.Application.Contaracts.Contact
{
    public interface IContactApplication
    {
        void Create(ContactCreateModel contact);
        void Edit(ContactEditModel editContact);
        void Block(int id);
        void UnBlock(int id);
        ContactEditModel GetDetails(int id);
        ContactViewModel GetContactInfo(int id);
        List<ContactViewModel> Search(ContactSearchModel contactSearchModel);
    }
}
