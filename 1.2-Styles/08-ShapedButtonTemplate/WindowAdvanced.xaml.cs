using System.Windows;
using System.Windows.Controls;

namespace _08_ShapedButtonTemplate
{
    public partial class WindowAdvanced : Window
    {
        public WindowAdvanced()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                MessageBox.Show(btn.Tag.ToString());
            }
        }
    }
}