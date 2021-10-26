using System.Windows;

namespace RoutedCommandExample
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