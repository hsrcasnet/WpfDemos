namespace BankApp.Enums
{
    public enum ProcessingOfAccountsArgs : byte
    {
        Open = 0,
        Close = 1,
        Edit = 2,
        Combine = 3,
        Transfer = 4,
        Withdraw = 5,
        Block = 6,
        Unblock = 7
    }
}
