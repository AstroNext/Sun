using Framework.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ShipperAgg
{
    public class Shipper : EntityBase
    {
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public string Description { get; set; }

        public Shipper(string name, string phonenumber, string description)
        {
            Name = name;
            Phonenumber = phonenumber;
            Description = description;
        }

        public void Edit(string name, string phonenumber, string description)
        {
            Name = name;
            Phonenumber = phonenumber;
            Description = description;
        }

        public void ChangeDescription(string dist)
        {
            Description = dist;
        }
    }
}
