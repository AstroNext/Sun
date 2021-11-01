using Sun.Application.Contaracts.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ContactAgg
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        void SaveChanges();
        bool Exist(string phonenumber);
        Contact Get(long id);
        ContactEditModel GetDetails(long id);
        ContactViewModel GetContactInfo(long id);
        List<ContactViewModel> Search(ContactSearchModel contactSearch);
    }
}
