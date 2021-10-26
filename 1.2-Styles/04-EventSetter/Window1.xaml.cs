using System.Windows;
using System.Windows.Controls;

namespace _04_EventSetter
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();
        }

        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button_Click was pressed." + ((Button)e.Source).Name.ToString());
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Help Button was pressed.");
            //e.Handled = true;
        }
    }
}