using System;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Services;
using WpfDependencyApp.ViewModels;

namespace WpfDependencyApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            this.InitializeComponent();
            this.DataContext = mainViewModel;
        }
    }
}
