using System.Collections.ObjectModel;
using System.Windows;

namespace WpfObservableCollection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new ShoppingMall();
        }
    }
}
