namespace PrismSampleApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            // Since this is a basic ShellWindow, there's nothing
            // to do here.
            // For enterprise apps, you could register up subscriptions
            // or other startup background tasks so that they get triggered
            // on startup, rather than putting them in the DashboardViewModel.
            //
            // For example, initiate the pulling of News Feeds, etc.

            this.Title = "Prism WPF Sample App";
        }
    }
}
