using Microsoft.EntityFrameworkCore;
using Sun.Application.Contaracts.Contact;
using Sun.Domain.ContactAgg;
using System.Collections.Generic;
using System.Linq;
using static Framework.Application.Tools;

namespace Sun.Infrastructure.EFCore.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly SunContext _context;

        public ContactRepository(SunContext context)
        {
            _context = context;
        }

        public void Create(Contact contact)
        {
            _context.Add(contact);
        }

        public bool Exist(string phonenumber)
        {
            return _context.Contacts.Any(x => x.Phonenumber == phonenumber);
        }

        public Contact Get(long id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public ContactViewModel GetContactInfo(long id)
        {
            return _context.Contacts.Select(x => new ContactViewModel
            {
                Id = x.Id,
                ClientId = x.ClientId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Adress = x.Adress,
                Phonenumber = x.Phonenumber,
                PostCode = x.PostCode,
                CreationTime = x.CreationDate.ToFarsi(),
                IsBlock = x.IsBlock,
                IsLogin = x.IsLogin

            }).FirstOrDefault(x => x.Id == id);
        }

        public ContactEditModel GetDetails(long id)
        {
            return _context.Contacts.Select(x => new ContactEditModel 
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Adress = x.Adress,
                Phonenumber = x.Phonenumber,
                PostCode = x.PostCode

            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ContactViewModel> Search(ContactSearchModel contactSearch)
        {
            var query = _context.Contacts.Select(x => new ContactViewModel
            {
                Id = x.Id,
                ClientId = x.ClientId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Adress = x.Adress,
                PostCode = x.PostCode,
                Phonenumber = x.Phonenumber,
                IsBlock = x.IsBlock,
                IsLogin = x.IsLogin,
                CreationTime = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(contactSearch.Name))
            {
                query = query.Where(x => x.FirstName.Contains(contactSearch.Name) || x.LastName.Contains(contactSearch.Name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
