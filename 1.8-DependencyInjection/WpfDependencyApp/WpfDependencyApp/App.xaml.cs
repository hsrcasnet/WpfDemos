using System.Diagnostics;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Services;
using WpfDependencyApp.Services.Logging;
using WpfDependencyApp.ViewModels;
using WpfDependencyApp.Views;

namespace WpfDependencyApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();

            // Configure logging
            serviceCollection.AddLogging(c =>
            {
                // Clear all default logging providers
                //c.ClearProviders();

                // Add debug console logging
                c.AddDebug();

                // Integrate logging frameworks such as NLog, SeriLog or log4net
                //c.AddNLog();
            });

            // Register services in DI container
            var useMockServices = true;
            if (useMockServices)
            {
                serviceCollection.AddSingleton<IEmployeeRepository, EmployeeRepositoryStub>();
            }
            else
            {
                serviceCollection.AddSingleton<IEmployeeRepository, EmployeeRepositoryEF>();
            }

            // Register pages and viewmodels
            serviceCollection.AddScoped<MainViewModel>();
            serviceCollection.AddScoped<MainWindow>();

            // Finally, create DI service provider
            this.serviceProvider = serviceCollection.BuildServiceProvider();

            this.serviceProvider.UsePresentationTraceSourcesLogging(o =>
            {
                o.SourceLevels = SourceLevels.Warning | SourceLevels.Error;
                o.TraceSources.FreezableSource.IsEnabled = false;
            });
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Resolve the root object of this application, MainWindow
            var mainWindow = this.serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
