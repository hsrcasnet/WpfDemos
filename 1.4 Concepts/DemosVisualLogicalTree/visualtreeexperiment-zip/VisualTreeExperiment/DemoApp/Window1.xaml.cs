using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SnooperLib;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            var snooper = new SnooperDialog()
            {
                Owner = this,
                TargetElement = this,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            snooper.Show();
        }

        void OnCreateNewItem(object sender, RoutedEventArgs e)
        {
            var listBox = this.Content as ListBox;
            if (listBox != null)
                listBox.Items.Add(new ListBoxItem { Content = DateTime.Now.Ticks });
        }
    }
}