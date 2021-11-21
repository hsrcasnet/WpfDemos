namespace BankApp.Models
{
    public interface IDivisionCode
    {
        int? Left { get; }

        int? Right { get; }

        public bool Equals(IDivisionCode obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            return this.Left == obj.Left &&
                   this.Right == obj.Right;
        }
    }
}
