using System;
using System.Windows;
using SnooperLib;

namespace VisualLogicalTree
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            WPFHelpers.VisualLogicalTree.DisplayLogicalTree(this);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            WPFHelpers.VisualLogicalTree.DisplayVisualTree(this);
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            var snooper = new SnooperDialog()
            {
                Owner = this,
                TargetElement = this,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            snooper.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            //base.OnClosed(e);
            //foreach (var w in this.OwnedWindows) { ((Window)w).Close();  }
        }
    }
}