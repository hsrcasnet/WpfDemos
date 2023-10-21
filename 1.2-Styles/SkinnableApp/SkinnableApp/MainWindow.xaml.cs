using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SkinnableApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CTOR Exception: " + ex.Message);
            }

            // Load the default skin.
            var mainGrid = this.Content as Grid;
            var item = mainGrid.ContextMenu.Items[0] as MenuItem;
            this.ApplySkinFromMenuItem(item);
        }

        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as MenuItem;

            // Update the checked state of the menu items.
            var mainGrid = (Grid)this.Content;
            foreach (MenuItem mi in mainGrid.ContextMenu.Items)
            {
                mi.IsChecked = mi == item;
            }

            // Load the selected skin.
            this.ApplySkinFromMenuItem(item);
        }

        private void ApplySkinFromMenuItem(MenuItem item)
        {
            // Get a relative path to the ResourceDictionary which
            // contains the selected skin.
            var skinDictPath = (string)item.Tag;
            var skinDictUri = new Uri(skinDictPath, UriKind.Relative);

            // Tell the Application to load the skin resources.
            var app = (DemoApp)Application.Current;
            app.ApplySkin(skinDictUri);
        }
    }
}