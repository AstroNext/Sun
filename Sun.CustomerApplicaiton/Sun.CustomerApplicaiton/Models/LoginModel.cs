using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.CustomerApplicaiton.Models
{
    public class LoginModel
    {
        public string Phonenumber { get; set; }
        public string ClientId { get; set; }
        public DateTime LoginDate { get; set; }

        public LoginModel(string phonenumber, string clientId)
        {
            Phonenumber = phonenumber;
            ClientId = clientId;
            LoginDate = DateTime.Now;
        }
    }
}
