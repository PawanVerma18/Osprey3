using Microsoft.Extensions.DependencyInjection;
using System;
using Osprey3.Services;
using Osprey3.ViewModels;
using Xamarin.Forms;

namespace Osprey3
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddHttpClient<IUserService, ApiUserService>(client =>
            {
                client.BaseAddress = new Uri("https://192.168.56.1:7035/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
             .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.CreateHandler());

            // Register view models
            services.AddTransient<RegistrationViewModel>();

            // Build the service provider
            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetRequiredService<T>();
    }
}