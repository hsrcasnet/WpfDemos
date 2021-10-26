using System.Windows;
using System.Windows.Media;

namespace ListBoxStyling
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = UserInfo.Users;

            Brush b = new SolidColorBrush(Colors.Green);
            this.Resources.Add("myBrush", b);
        }
    }
}