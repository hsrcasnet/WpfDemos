using System.Collections;
using System.Windows;

namespace BankApp.Views
{
    public partial class SelectTwoBankAccountsWindow : Window
    {
        public SelectTwoBankAccountsWindow()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty BankAccountsProperty =
            DependencyProperty.Register(nameof(BankAccounts),
                                        typeof(IEnumerable),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(IEnumerable)));

        public IEnumerable BankAccounts
        {
            get => (IEnumerable)this.GetValue(BankAccountsProperty);
            set => this.SetValue(BankAccountsProperty, value);
        }

        public static readonly DependencyProperty SelectedBankAccount1Property =
            DependencyProperty.Register(nameof(SelectedBankAccount1),
                                        typeof(object),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(object)));

        public object SelectedBankAccount1
        {
            get => this.GetValue(SelectedBankAccount1Property);
            set => this.SetValue(SelectedBankAccount1Property, value);
        }

        public static readonly DependencyProperty SelectedBankAccount2Property =
            DependencyProperty.Register(nameof(SelectedBankAccount2),
                                        typeof(object),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(object)));

        public object SelectedBankAccount2
        {
            get => this.GetValue(SelectedBankAccount2Property);
            set => this.SetValue(SelectedBankAccount2Property, value);
        }

    }
}
