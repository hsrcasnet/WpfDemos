using System.Windows;
using System.Windows.Data;

namespace SortingFilteringGrouping
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new ShoppingMallViewModel();
        }

        private void CustomerCollectionViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            e.Accepted = e.Item is Customer person && person.Age > 18;
        }
    }
}