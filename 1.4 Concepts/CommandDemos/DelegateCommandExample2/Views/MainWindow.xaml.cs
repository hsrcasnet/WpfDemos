using System.Windows;
using DelegateCommandExample2.ViewModels;

namespace DelegateCommandExample2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new KitchenViewModel();
        }
    }
}
