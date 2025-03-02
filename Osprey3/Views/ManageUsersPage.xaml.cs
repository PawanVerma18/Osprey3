using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Osprey3.Models;
using Osprey3.Services;

namespace Osprey3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageUsersPage : ContentPage
    {
        private readonly UserService _userService = new UserService();

        public ManageUsersPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                UsersListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load users: {ex.Message}", "OK");
            }
        }

        private async void OnEditUserClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var user = button?.BindingContext as User;

            if (user != null)
            {
                await Navigation.PushAsync(new EditUserPage(user));
            }
        }
    }
}