using System.Windows;
using WpfDependencyApp.ViewModels;

namespace WpfDependencyApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            this.InitializeComponent();
            this.DataContext = mainViewModel;
        }
    }
}
