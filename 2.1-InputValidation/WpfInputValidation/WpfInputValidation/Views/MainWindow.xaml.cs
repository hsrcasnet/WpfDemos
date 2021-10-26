using System.Windows;
using WpfInputValidation.ViewModels;

namespace WpfInputValidation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new CustomerViewModel();
        }
    }
}
