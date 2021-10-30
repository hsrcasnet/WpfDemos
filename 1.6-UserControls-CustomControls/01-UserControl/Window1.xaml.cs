using System.Collections.Generic;
using System.Windows;

namespace _01_UserControl
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();

            var propertyItemViewModels = new List<PropertyItemViewModel>
            {
                new PropertyItemViewModel { Title = "First name" },
                new PropertyItemViewModel { Title = "Last name" },
                new PropertyItemViewModel { Title = "Address" }
            };

            this.DataContext = propertyItemViewModels;
        }
    }
}