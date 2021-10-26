using System.Windows;

namespace WpfMultilingual
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