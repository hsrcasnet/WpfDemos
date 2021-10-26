using System.Windows;

namespace MultiBinding
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
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