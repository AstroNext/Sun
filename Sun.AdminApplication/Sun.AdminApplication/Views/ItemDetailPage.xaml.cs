using Sun.AdminApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Sun.AdminApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}