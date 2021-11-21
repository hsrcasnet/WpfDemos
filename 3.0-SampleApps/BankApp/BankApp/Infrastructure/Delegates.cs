using BankApp.Enums;

namespace BankApp.Infrastructure
{
    public delegate void RepositoryEventHandler(object sender, RepositoryArgs args);
    public delegate void ManagerEventHandler(object sender, ManagerArgs args);
    public delegate void ProcessingOfAccountsEventHandler(object sender, ProcessingOfAccountsArgs args);
}
