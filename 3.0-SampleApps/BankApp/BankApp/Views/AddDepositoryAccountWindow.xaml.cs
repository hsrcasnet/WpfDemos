using System;
using System.Collections.Generic;
using System.Windows;
using BankApp.Enums;

namespace BankApp.Views
{
    public partial class AddDepositoryAccountWindow : Window
    {

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register(nameof(Amount),
                                        typeof(double?),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(default(double?)));

        public double? Amount
        {
            get => (double?)this.GetValue(AmountProperty);
            set => this.SetValue(AmountProperty, value);
        }

        public static readonly DependencyProperty InterestRateProperty =
            DependencyProperty.Register(nameof(InterestRate),
                                        typeof(double?),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(default(double?)));

        public double? InterestRate
        {
            get => (double?)this.GetValue(InterestRateProperty);
            set => this.SetValue(InterestRateProperty, value);
        }

        [Obsolete("Move to viewmodel")]
        public List<string> DepositStatusList { get; set; } = new List<string> { "Without capitalization", "With capitalization" };

        public static readonly DependencyProperty SelectedDepositStatusProperty =
            DependencyProperty.Register(nameof(SelectedDepositStatus),
                                        typeof(DepositStatus),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(default(DepositStatus)));

        public DepositStatus SelectedDepositStatus
        {
            get => (DepositStatus)this.GetValue(SelectedDepositStatusProperty);
            set => this.SetValue(SelectedDepositStatusProperty, value);
        }

        public static readonly DependencyProperty AmountVisibilityProperty =
            DependencyProperty.Register(nameof(AmountVisibility),
                                        typeof(Visibility),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        public Visibility AmountVisibility
        {
            get => (Visibility)this.GetValue(AmountVisibilityProperty);
            set => this.SetValue(AmountVisibilityProperty, value);
        }

        public static readonly DependencyProperty InterestRateVisibilityProperty =
            DependencyProperty.Register(nameof(InterestRateVisibility),
                                        typeof(Visibility),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        public Visibility InterestRateVisibility
        {
            get => (Visibility)this.GetValue(InterestRateVisibilityProperty);
            set => this.SetValue(InterestRateVisibilityProperty, value);
        }

        public static readonly DependencyProperty DepositStatusVisibilityProperty =
            DependencyProperty.Register(nameof(DepositStatusVisibility),
                                        typeof(Visibility),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        public Visibility DepositStatusVisibility
        {
            get => (Visibility)this.GetValue(DepositStatusVisibilityProperty);
            set => this.SetValue(DepositStatusVisibilityProperty, value);
        }

        public static readonly DependencyProperty TextOfInputButtonProperty =
            DependencyProperty.Register(nameof(TextOfInputButton),
                                        typeof(string),
                                        typeof(AddDepositoryAccountWindow),
                                        new PropertyMetadata("Ok"));

        public string TextOfInputButton
        {
            get => (string)this.GetValue(TextOfInputButtonProperty);
            set => this.SetValue(TextOfInputButtonProperty, value);
        }

        public AddDepositoryAccountWindow() => this.InitializeComponent();
    }
}
