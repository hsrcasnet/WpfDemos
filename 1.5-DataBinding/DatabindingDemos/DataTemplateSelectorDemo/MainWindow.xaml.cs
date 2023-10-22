using System.Windows;
using DataTemplateSelectorDemo.ViewModels;

namespace DataTemplateSelectorDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
