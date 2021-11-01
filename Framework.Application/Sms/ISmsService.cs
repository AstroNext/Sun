using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Application.Sms
{
    public interface ISmsService
    {
        void SendSms(string phonenumber, string text);
    }
}
