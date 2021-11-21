using BankApp.Models;
using BankApp.Views;

namespace BankApp.Services
{
    public class BankCustomerInfoDialog : IInformationDialog<IBankCustomer>
    {
        public void Dialog(IBankCustomer data)
        {
            var dialog = new InfoWindow();
            dialog.Show();
            dialog.Close();
        }
    }
}
