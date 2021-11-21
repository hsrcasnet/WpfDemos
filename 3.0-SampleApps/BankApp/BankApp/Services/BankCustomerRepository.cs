using BankApp.Models;

namespace BankApp.Services
{
    public class BankCustomerRepository : RepositoryInMemory<IBankCustomer>
    {
        public BankCustomerRepository() : base(TestData.BankCustomers)
        {
        }

        protected override void Update(IBankCustomer source, IBankCustomer destination)
        {
            destination.Id = source.Id;
            destination.Blocking = source.Blocking;
            destination.Passport = source.Passport;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Reliability = source.Reliability;
            destination.ClientStatus = source.ClientStatus;
            destination.Description = source.Description;
            destination.Email = source.Email;
            destination.DepositoryAccounts = source.DepositoryAccounts;
        }
    }
}
