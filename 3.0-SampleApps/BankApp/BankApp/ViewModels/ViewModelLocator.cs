using Microsoft.Extensions.DependencyInjection;

namespace BankApp.ViewModels
{

    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowVM => App.Host.Services.GetRequiredService<MainWindowViewModel>();

        public MainUserControlViewModel MainUserControlVM => App.Host.Services.GetRequiredService<MainUserControlViewModel>();

        public MainMenuUserControlViewModel MainMenuUserControlVM => App.Host.Services.GetRequiredService<MainMenuUserControlViewModel>();
    }
}
