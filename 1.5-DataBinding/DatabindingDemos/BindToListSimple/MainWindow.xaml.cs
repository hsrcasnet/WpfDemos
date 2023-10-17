using System.Windows;

namespace BindToListSimple
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = PersonFactory.GetPersons();
            this.InitializeComponent();
        }
    }
}