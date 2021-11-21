using System;
using System.Windows;
using BankApp.Services;
using BankApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApp
{
    public partial class App : Application
    {
        private static IHost host;

        public static IHost Host => host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            // Register Services
            services.AddSingleton<DepartmentRepository>();
            services.AddSingleton<BankCustomerRepository>();
            services.AddSingleton<DepositoryAccountRepository>();

            services.AddSingleton<DepartmentsManager>();
            services.AddSingleton<BankCustomersManager>();
            services.AddSingleton<DepositoryAccountsManager>();

            services.AddTransient<FileIOService>();
            services.AddTransient<FileDialog>();
            services.AddTransient<BankCustomerDialogService>();
            services.AddTransient<DepositoryAccountDialog>();
            services.AddTransient<ProcessingOfDepositoryAccounts>();
            services.AddTransient<BankCustomerInfoDialog>();

            // Register ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainUserControlViewModel>();
            services.AddTransient<MainMenuUserControlViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            App.host = null;
        }
    }
}
