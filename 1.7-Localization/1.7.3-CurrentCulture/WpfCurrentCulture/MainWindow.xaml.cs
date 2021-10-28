using System.Windows;
using WpfCurrentCulture.ViewModels;

namespace WpfCurrentCulture
{
    public partial class MainWindow : Window
    {
        private readonly CultureViewModel viewModel;

        public MainWindow()
        {
            this.InitializeComponent();


            this.viewModel = new CultureViewModel();
            this.DataContext = this.viewModel;
        }

        private void ResetCurrentCulture(object sender, RoutedEventArgs e)
        {
            this.viewModel.ResetCurrentCulture();
        }

        private void ResetCurrentUICulture(object sender, RoutedEventArgs e)
        {
            this.viewModel.ResetCurrentUICulture();
        }
    }
}