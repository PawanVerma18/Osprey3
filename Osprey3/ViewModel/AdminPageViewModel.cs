using System.Windows.Input;
using Xamarin.Forms;
using Osprey3.Views;

namespace Osprey3.ViewModels
{
    public class AdminPageViewModel
    {
        public ICommand ManageUsersCommand { get; }
        public ICommand ViewReportsCommand { get; }
        public ICommand BackCommand { get; }

        private readonly INavigation _navigation;

        public AdminPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            // Initialize commands
            ManageUsersCommand = new Command(OnManageUsersClicked);
            ViewReportsCommand = new Command(OnViewReportsClicked);
            BackCommand = new Command(OnBackClicked);
        }

        private async void OnManageUsersClicked()
        {
            // Navigate to ManageUsersPage
            await _navigation.PushAsync(new ManageUsersPage());
        }

        private async void OnViewReportsClicked()
        {
            // Navigate to ViewReportsPage
            await _navigation.PushAsync(new ViewReportsPage());
        }

        private async void OnBackClicked()
        {
            // Navigate back to MainScreen
            await _navigation.PopAsync();
        }
    }
}