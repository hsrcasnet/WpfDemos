using System.Windows;
using EventToCommandDemo2.ViewModels;

namespace EventToCommandDemo2.Views
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
