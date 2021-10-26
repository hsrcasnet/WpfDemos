using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace _01_UserControl
{
    public partial class MyOwnUserControl : UserControl
    {
        public MyOwnUserControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ViewModel)((ButtonBase)sender).DataContext;
            MessageBox.Show($"Title={vm.Title}, Value={vm.Value}");
        }
    }
}