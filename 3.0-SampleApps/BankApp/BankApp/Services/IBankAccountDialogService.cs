using BankApp.Models;

namespace BankApp.Services
{
    public interface IBankAccountDialogService<T> : IDialogService<T> where T : IBankAccount
    {
        T Create();
    }
}
