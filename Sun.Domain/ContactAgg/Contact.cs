using Framework.Application.Domain;
using Sun.Domain.AdminAgg;
using Sun.Domain.CartAgg;
using Sun.Domain.OrderAgg;
using System;
using System.Collections.Generic;

namespace Sun.Domain.ContactAgg
{
    public class Contact : EntityBase
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string Phonenumber { get; set; }
        public string AuthCode { get; set; }
        public bool IsBlock { get; set; }
        public bool IsLogin { get; set; }
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
        public Contact() { }

        public Contact(string firstName, string lastName, string adress, string postCode, string phonenumber)
        {
            ClientId = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            PostCode = postCode;
            Phonenumber = phonenumber;
            AuthCode = new Random().Next(10000,999999).ToString();
            IsBlock = false;
            IsLogin = false;
            Orders = new List<Order>();
        }

        public void Edit(string first, string lastname, string adress, string postcode, string phonenumber)
        {
            FirstName = first;
            LastName = lastname;
            Adress = adress;
            PostCode = postcode;
            Phonenumber = phonenumber;
        }

        public void Block()
        {
            IsBlock = true;
        }

        public void UnBlock()
        {
            IsBlock = false;
        }
    }
}
