using System;
using System.Collections.Generic;
using BankApp.Models;
using BankApp.Views;

namespace BankApp.Services
{
    public class DepositoryAccountDialog : IBankAccountDialogService<IDepositoryAccount>
    {
        public IDepositoryAccount Create()
        {
            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Add";
            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            return new DepositoryAccount(0, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
        }

        public IDepositoryAccount Edit(IDepositoryAccount bankAccount)
        {
            if (bankAccount is null)
            {
                throw new ArgumentNullException("Account must not be null");
            }

            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Apply";
            dialog.AmountVisibility = System.Windows.Visibility.Collapsed;
            dialog.InterestRate = bankAccount.InterestRate;
            dialog.SelectedDepositStatus = bankAccount.DepositStatus;

            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            return new DepositoryAccount(bankAccount.Id, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
        }

        public IDepositoryAccount Selected(IList<IDepositoryAccount> bankAccounts)
        {
            if (bankAccounts is null)
            {
                throw new ArgumentNullException("Bank accounts must not be null");
            }

            var dialog = new SelectedBankAccountWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            return dialog.SelectedBankAccount as IDepositoryAccount;
        }

        public void SelectTwoBankAccounts(IList<IDepositoryAccount> bankAccounts, out IDepositoryAccount bankAccounts1, out IDepositoryAccount bankAccounts2)
        {
            if (bankAccounts is null)
            {
                throw new ArgumentNullException("Bank accounts must not be null");
            }

            bankAccounts1 = null;
            bankAccounts2 = null;

            var dialog = new SelectTwoBankAccountsWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            bankAccounts1 = dialog.SelectedBankAccount1 as DepositoryAccount;
            bankAccounts2 = dialog.SelectedBankAccount2 as DepositoryAccount;
        }

        public double? ChangeAmountOfBankAccount()
        {
            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Apply";
            dialog.InterestRateVisibility = System.Windows.Visibility.Collapsed;
            dialog.DepositStatusVisibility = System.Windows.Visibility.Collapsed;

            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            return dialog.Amount;
        }
    }
}
