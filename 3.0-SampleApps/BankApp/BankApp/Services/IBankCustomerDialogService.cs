using BankApp.Enums;
using BankApp.Models;

namespace BankApp.Services
{
    public interface IBankCustomerDialogService : IDialogService<IBankCustomer>
    {
        IBankCustomer Create(Status clientStatus);
    }
}
