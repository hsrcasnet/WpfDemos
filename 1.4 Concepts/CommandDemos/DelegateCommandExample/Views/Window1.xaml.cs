using System.Windows;
using DelegateCommandExample.ViewModels;

namespace DelegateCommandExample
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