using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Osprey3.ViewModels;

namespace Osprey3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();

            // Set BindingContext to AdminPageViewModel
            BindingContext = new AdminPageViewModel(Navigation);
        }
    }
}