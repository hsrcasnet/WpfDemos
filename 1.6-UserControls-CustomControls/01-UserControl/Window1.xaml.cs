using System.Collections.Generic;
using System.Windows;

namespace _01_UserControl
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();

            var viewModel = new List<ViewModel>();

            viewModel.Add(new ViewModel { Title = "First name" });
            viewModel.Add(new ViewModel { Title = "Last name" });
            viewModel.Add(new ViewModel { Title = "Address" });

            this.DataContext = viewModel;
        }
    }
}