using BankApp.Enums;

namespace BankApp.Models
{
    public interface IDepositoryAccount : IBankAccount
    {
        public DepositStatus DepositStatus { get; set; }
    }
}
