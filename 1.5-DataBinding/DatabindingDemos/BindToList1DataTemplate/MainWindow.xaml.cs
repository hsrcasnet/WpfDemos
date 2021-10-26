using System.Windows;
using BindToList;

namespace BindToList1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            PeopleFactory p = new PeopleFactory();
            var people = p.GetPeople();
            this.DataContext = people;
        }
    }
}