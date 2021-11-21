using BankApp.Enums;

namespace BankApp.Models
{

    public interface IBankAccount : IElement
    {
        double? Amount { get; set; }

        double? InterestRate { get; set; }

        AccountStatus AccountStatus { get; }
    }
}
