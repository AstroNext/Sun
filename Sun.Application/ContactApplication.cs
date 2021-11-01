using Sun.Application.Contaracts.Contact;
using Sun.Domain.ContactAgg;
using System;
using System.Collections.Generic;

namespace Sun.Application
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactRepository _repo;

        public ContactApplication(IContactRepository repo)
        {
            _repo = repo;
        }

        public void Block(int id)
        {
            var contact = _repo.Get(id);

            if (contact == null)
            {
                return;
            }

            contact.Block();
            _repo.SaveChanges();
        }

        public void Create(ContactCreateModel contact)
        {
            if (_repo.Exist(contact.Phonenumber))
            {
                return;
            }
            var cont = new Contact(contact.FirstName, contact.LastName, contact.Adress, contact.PostCode, contact.Phonenumber);
            _repo.Create(cont);
            _repo.SaveChanges();
        }

        public void Edit(ContactEditModel editContact)
        {
            var contact = _repo.Get(editContact.Id);

            if (contact == null)
            {
                return;
            }

            contact.Edit(editContact.FirstName, editContact.LastName, editContact.Adress, editContact.PostCode, editContact.Phonenumber);
            _repo.SaveChanges();
        }

        public List<ContactViewModel> Search(ContactSearchModel contactSearchModel)
        {
            return _repo.Search(contactSearchModel);
        }

        public ContactEditModel GetDetails(int id)
        {
            return _repo.GetDetails(id);
        }

        public void UnBlock(int id)
        {
            var contact = _repo.Get(id);

            if (contact == null)
            {
                return;
            }

            contact.UnBlock();
            _repo.SaveChanges();
        }

        public ContactViewModel GetContactInfo(int id)
        {
            return _repo.GetContactInfo(id);
        }
    }
}
