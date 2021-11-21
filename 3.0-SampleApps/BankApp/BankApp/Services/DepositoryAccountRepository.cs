using BankApp.Models;

namespace BankApp.Services
{

    public class DepositoryAccountRepository : RepositoryInMemory<IDepositoryAccount>
    {
        public DepositoryAccountRepository() : base(TestData.DepositoryAccounts) { }

        protected override void Update(IDepositoryAccount source, IDepositoryAccount destination)
        {
            destination.Id = source.Id;
            destination.Blocking = source.Blocking;
            destination.Amount = source.Amount;
            destination.InterestRate = source.InterestRate;
            destination.DepositStatus = source.DepositStatus;
        }
    }
}
