using Sun.AdminApplication.Services;
using Sun.AdminApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sun.AdminApplication
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
