using Sun.CustomerApplicaiton.Services;
using Sun.CustomerApplicaiton.Views;
using System.Linq;
using Xamarin.Forms;

namespace Sun.CustomerApplicaiton
{
    public partial class App : Application
    {
        LoginService ls;
        public App()
        {
            InitializeComponent();
            ControleUserAuth();
        }

        protected override void OnStart()
        {
            ControleUserAuth();
        }

        protected override void OnSleep()
        {
            ControleUserAuth();
        }

        protected override void OnResume()
        {
            ControleUserAuth();
        }

        private void ControleUserAuth()
        {
            ls = new LoginService();
            var name = GetData();

            if (name != null && !string.IsNullOrEmpty(name))
            {
                MainPage = new AppShell();
            }
            MainPage = new LoginPage();
        }

        private string GetData()
        {
            try
            {
                return ls.IsExist().Result.FirstOrDefault().Properties["Name"];
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
