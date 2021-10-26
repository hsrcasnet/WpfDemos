using System.Windows;

namespace SimpleBinding
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        readonly CarInfo ci;

        public Window1()
        {
            this.InitializeComponent();

            this.ci = new CarInfo();
            this.ci.Make = "BMW";
            this.ci.Model = "M3";

            this.DataContext = this.ci;

            this.Loaded += delegate { this.btnReadData.Click += new RoutedEventHandler(this.BtnReadData_Click); };
        }

        private void BtnReadData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.ci.Make + " " + this.ci.Model);
        }
    }
}