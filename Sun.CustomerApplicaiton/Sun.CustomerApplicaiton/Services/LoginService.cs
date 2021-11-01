using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Sun.CustomerApplicaiton.Services
{
    public class LoginService
    {
        private readonly string _serviceId = "SunCredential";
        public async void SaveCredentials(string phonenumber, string clientId, string Name)
        {
            if (!string.IsNullOrWhiteSpace(phonenumber) && !string.IsNullOrWhiteSpace(clientId))
            {
                Account account = new Account(phonenumber);
                account.Properties.Add("Phonenumber", phonenumber);
                account.Properties.Add("Name", Name);
                account.Properties.Add("Clientid", clientId);
                await SecureStorageAccountStore.SaveAsync(account, _serviceId);
            }
        }
        public void RemoveCredential()
        {
            SecureStorageAccountStore.RemoveAsync();
        }

        public async Task<bool> IsAuth(string us, string pass)
        {
            var accounts = await SecureStorageAccountStore.FindAccountsForServiceAsync(_serviceId);
            return accounts.Exists(x => x.Properties["Password"] == pass && x.Properties["Name"] == us);
        }

        public async Task<List<Account>> IsExist()
        {
            var accounts = await SecureStorageAccountStore.FindAccountsForServiceAsync(_serviceId);
            return accounts;
        }

        //public User GetUserData(string us, string pass)
        //{
        //    return users.Find(x => x.Password == pass && x.Username == us);
        //}

        //public bool GetUserAuth(string us, string pass)
        //{
        //    return users.Any(x => x.Password == pass && x.Username == us);
        //}
    }
}
