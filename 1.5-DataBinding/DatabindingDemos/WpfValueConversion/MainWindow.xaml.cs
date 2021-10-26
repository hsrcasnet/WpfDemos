using System;
using System.Windows;

namespace WpfValueConversion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new PersonViewModel();
        }
    }
}
