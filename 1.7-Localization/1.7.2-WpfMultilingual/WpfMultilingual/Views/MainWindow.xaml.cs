using System.Windows;
using WpfMultilingual.ViewModels;

namespace WpfMultilingual.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel(App.TranslationManager);
        }
    }
}