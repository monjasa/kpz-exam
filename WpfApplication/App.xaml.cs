using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApplication.Services;
using WpfApplication.ViewModels;
using WpfApplication.Views;

namespace WpfApplication
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:5001/")
                };
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            });
            
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            
            services.AddScoped<ITrackService, HttpTrackService>();
        }
        
        protected override void OnStartup(StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}