using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Osprey3.Models;
using Osprey3.Services;
using System;

namespace Osprey3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        private readonly UserService _userService = new UserService();
        private User _user;

        public EditUserPage(User user)
        {
            InitializeComponent();
            _user = user;
            BindingContext = _user;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            try
            {
                // Update the user in the API
                await _userService.UpdateUserAsync(_user);

                // Navigate back to ManageUsersPage
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save changes: {ex.Message}", "OK");
            }
        }
    }
}