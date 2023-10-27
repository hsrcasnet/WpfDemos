namespace CustomAttachedProperties3
{
    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public AddressViewModel InvoiceAddress { get; set; }

        public AddressViewModel ShippingAddress { get; set; }
    }
}