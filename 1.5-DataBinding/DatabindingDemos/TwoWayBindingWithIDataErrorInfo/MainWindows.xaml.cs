using System.Windows;

namespace TwoWayBinding
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new SomeData() { Value2 = 10 };
        }
    }
}