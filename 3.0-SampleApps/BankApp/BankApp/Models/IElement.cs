namespace BankApp.Models
{

    public interface IElement : IEntity
    {
        bool Blocking { get; set; }
    }
}
