using System.Windows;

namespace WpfAutofac
{
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.Start();   

            var window = Bootstrapper.RootView;
            window.DataContext = Bootstrapper.RootViewModel;
            window.Closed += (s, a) => { Bootstrapper.Stop(); };
            window.Show();
        }
    }
}