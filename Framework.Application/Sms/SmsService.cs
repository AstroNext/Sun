using System;
using Microsoft.Extensions.Configuration;
using PayamakPanel.Core;

namespace Framework.Application.Sms
{
    public class SmsService : ISmsService
    {
        public static IConfiguration Configuration { get; set;}
        public static void Configure(IConfiguration cfg)
        {
            Configuration = cfg;
        }
        public void SendSms(string phonenumber, string text)
        {
            FaraApi fa = new FaraApi();

            var user = Configuration.GetSection("SmsPanel").GetValue<string>("Username");
            var pass = Configuration.GetSection("SmsPanel").GetValue<string>("Password");
            var number = Configuration.GetSection("SmsPanel").GetValue<string>("Number");

            var st = fa.SendSms(user, pass, number, phonenumber, text);
        }
    }
}
