using System.Windows;

namespace CustomAttachedProperties3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = new UserProfileViewModel
            {
                Username = "thomasgalliker",
                InvoiceAddress = new AddressViewModel
                {
                    Street = "Company Address 22",
                    ZipCode = 6330,
                    Place = "Cham"
                },
                ShippingAddress = new AddressViewModel
                {
                    Street = "Private Street 33",
                    ZipCode = 6300,
                    Place = "Zug"
                },
            };
        }
    }
}
