using System.Windows;
using DelegateCommandWith.Services;
using DelegateCommandWith.ViewModels;

namespace DelegateCommandWith.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new KitchenViewModel(new KitchenService(), new DialogService());
        }
    }
}
