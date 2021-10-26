using System.Windows;

namespace MultiBinding
{
    public enum OccupationKind
    {
        Student,
        Skilled,
        Professional
    }
    public partial class MainWindow : Window
    {
 

        public MainWindow()
        {
            InitializeComponent();
            // Set the DataContext to a person object
            this.DataContext =
                new Person()
                {
                    FirstName = "Elin",
                    LastName = "Binkles",
                    Age = 26,
                    Occupation = "Professional"
                };
        }
    }
}
