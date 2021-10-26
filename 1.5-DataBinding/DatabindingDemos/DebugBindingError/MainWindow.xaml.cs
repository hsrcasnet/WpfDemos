using System.Windows;

namespace DebugBindingError
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new Person { FirstName = "Thomas" };
        }
    }
}