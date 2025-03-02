using Osprey3.Services;
using Osprey3.ViewModels;
using Xamarin.Forms;

namespace Osprey3.Views
{
    public partial class Registration : ContentPage
    {
        public Registration(IUserService userService)
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel(userService, Navigation);
        }
    }
}