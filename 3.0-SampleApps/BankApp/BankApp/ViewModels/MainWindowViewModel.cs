namespace BankApp.ViewModels
{
    public class MainWindowViewModel : BaseClassViewModelINPC
    {
        public string Title { get; protected set; }

        public MainWindowViewModel()
        {
            this.Title = "BankApp";
        }
    }
}
