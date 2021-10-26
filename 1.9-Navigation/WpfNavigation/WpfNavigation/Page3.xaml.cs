using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfNavigation
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var url = this.NavigationService.CurrentSource;
            Debug.WriteLine(url);
        }
    }
}