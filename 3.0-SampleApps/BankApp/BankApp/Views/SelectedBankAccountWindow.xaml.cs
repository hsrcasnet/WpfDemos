using System.Collections;
using System.Windows;

namespace BankApp.Views
{
    public partial class SelectedBankAccountWindow : Window
    {
        public SelectedBankAccountWindow()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty BankAccountsProperty =
            DependencyProperty.Register(nameof(BankAccounts),
                                        typeof(IEnumerable),
                                        typeof(SelectedBankAccountWindow),
                                        new PropertyMetadata(default(IEnumerable)));

        public IEnumerable BankAccounts
        {
            get => (IEnumerable)this.GetValue(BankAccountsProperty);
            set => this.SetValue(BankAccountsProperty, value);
        }

        public static readonly DependencyProperty SelectedBankAccountProperty =
            DependencyProperty.Register(nameof(SelectedBankAccount),
                                        typeof(object),
                                        typeof(SelectedBankAccountWindow),
                                        new PropertyMetadata(default(object)));

        public object SelectedBankAccount
        {
            get => this.GetValue(SelectedBankAccountProperty);
            set => this.SetValue(SelectedBankAccountProperty, value);
        }

    }
}
