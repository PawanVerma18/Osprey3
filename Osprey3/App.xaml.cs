using Osprey3.Views;
using Xamarin.Forms;

namespace Osprey3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.ConfigureServices(); // Configure dependency injection

            // Resolve MainScreen with dependencies
            var userService = Startup.Resolve<IUserService>();
            MainPage = new NavigationPage(new MainScreen(userService)); // Set MainScreen as the root page
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}