using System.Collections.Generic;
using System.Windows;
using BankApp.Enums;

namespace BankApp.Views
{
    public partial class AddCreditAccountWindow : Window
    {
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register(
                nameof(Amount),
                typeof(double?),
                typeof(AddCreditAccountWindow),
                new PropertyMetadata(default(double?)));

        public double? Amount
        {
            get => (double?)this.GetValue(AmountProperty);
            set => this.SetValue(AmountProperty, value);
        }

        public static readonly DependencyProperty InterestRateProperty =
            DependencyProperty.Register(nameof(InterestRate),
                                        typeof(double?),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(double?)));

        public double? InterestRate
        {
            get => (double?)this.GetValue(InterestRateProperty);
            set => this.SetValue(InterestRateProperty, value);
        }

        public static readonly DependencyProperty CreditTermProperty =
            DependencyProperty.Register(nameof(CreditTerm),
                                        typeof(byte?),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(byte?)));

        public byte? CreditTerm
        {
            get => (byte?)this.GetValue(CreditTermProperty);
            set => this.SetValue(CreditTermProperty, value);
        }

        public List<string> CreditStatusList { get; set; } = new List<string> { "Annuity", "Differentiated" };

        public static readonly DependencyProperty SelectedCreditStatusProperty =
            DependencyProperty.Register(nameof(SelectedCreditStatus),
                                        typeof(CreditStatus),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(CreditStatus)));

        public CreditStatus SelectedCreditStatus
        {
            get => (CreditStatus)this.GetValue(SelectedCreditStatusProperty);
            set => this.SetValue(SelectedCreditStatusProperty, value);
        }

        public AddCreditAccountWindow() => this.InitializeComponent();
    }
}
