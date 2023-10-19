using System.Windows;
using System.Windows.Controls;


namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Menu : Window
    {

        public Menu()
        {
            this.InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // Get the current button.
            var cmd = (Button)e.OriginalSource;

            // Create an instance of the window named
            // by the current button.
            var type = this.GetType();
            var assembly = type.Assembly;
            var win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content);

            // Show the window.
            win.ShowDialog();
        }
    }
}