using System.Windows;

namespace SimpleObject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new Person { Age = 34, FirstName = "Hans", LastName = "Muster" };
        }
    }
}