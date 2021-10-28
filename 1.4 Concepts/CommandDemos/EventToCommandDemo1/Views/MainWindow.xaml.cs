using System.Windows;
using EventToCommandDemo1.ViewModels;

namespace EventToCommandDemo1.Views
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
