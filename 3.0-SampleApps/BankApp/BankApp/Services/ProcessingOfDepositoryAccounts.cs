using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using BankApp.Enums;
using BankApp.Infrastructure;
using BankApp.Models;

namespace BankApp.Services
{
    public class ProcessingOfDepositoryAccounts
    {
        private readonly DepositoryAccountsManager depositoryAccountsManager;
        private readonly DepositoryAccountDialog depositoryAccountDialog;
        private DispatcherTimer timer;
        private byte k = 1;

        public ProcessingOfDepositoryAccounts(DepositoryAccountsManager depositoryAccountsManager, DepositoryAccountDialog depositoryAccountDialog)
        {
            this.depositoryAccountsManager = depositoryAccountsManager;
            this.depositoryAccountDialog = depositoryAccountDialog;
        }

        public event ProcessingOfAccountsEventHandler ProcessingOfAccountsEvent;

        public IList<IDepositoryAccount> DepositoryAccounts => this.depositoryAccountsManager.DepositoryAccounts;

        public bool OpenAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException("Customer must not be null");
            }

            var depositoryAccount = this.depositoryAccountDialog.Create();
            if (depositoryAccount is null)
            {
                return false;
            }

            var result = this.depositoryAccountsManager.Create(depositoryAccount, bankCustomer);
            if (result)
            {
                ProcessingOfAccountsEvent?.Invoke(depositoryAccount, ProcessingOfAccountsArgs.Open);
            }

            return result;
        }

        public bool CloseAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return false;
            }

            if (account.Blocking)
            {
                MessageBox.Show("Account is blocked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var result = this.depositoryAccountsManager.Delete(account, bankCustomer);
            if (result)
            {
                ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Close);
            }

            return result;
        }

        public bool EditAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return false;
            }

            if (account.Blocking)
            {
                MessageBox.Show("Account is blocked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var tempDepositoryAccount = this.depositoryAccountDialog.Edit(account);
            if (tempDepositoryAccount is null)
            {
                return false;
            }

            this.depositoryAccountsManager.Update(tempDepositoryAccount);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Edit);

            return true;
        }

        public bool CombiningAccounts(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException("Customer must not be null");
            }

            this.depositoryAccountDialog.SelectTwoBankAccounts(bankCustomer.DepositoryAccounts, out var account1, out var account2);
            if (account1 is null || account2 is null)
            {
                return false;
            }

            if (account1.Blocking || account2.Blocking)
            {
                MessageBox.Show("Account is blocked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (account1.Id == account2.Id)
            {
                MessageBox.Show("Source and target accounts must not have the same ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var tempAmount = account2.Amount;
            var result = this.depositoryAccountsManager.Delete(account2, bankCustomer);

            if (result)
            {
                account1.Amount += tempAmount;
                this.depositoryAccountsManager.Update(account1);
                ProcessingOfAccountsEvent?.Invoke(account1, ProcessingOfAccountsArgs.Combine);

                return true;
            }

            return false;
        }

        public bool TransferToAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return false;
            }

            if (account.Blocking)
            {
                MessageBox.Show("Account is blocked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var result = this.depositoryAccountDialog.ChangeAmountOfBankAccount();
            if (result is null)
            {
                return false;
            }

            if (result < 0)
            {
                MessageBox.Show("Amount cannot be less than zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            account.Amount += result;

            this.depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Transfer);

            return true;
        }

        public double? WithdrawFromAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return null;
            }

            if (account.Blocking)
            {
                MessageBox.Show("Account is blocked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            var result = this.depositoryAccountDialog.ChangeAmountOfBankAccount();
            if (result is null)
            {
                return null;
            }

            if (result < 0)
            {
                MessageBox.Show("Amount cannot be less than zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            result = Math.Round((double)result, 2, MidpointRounding.ToEven);

            if (result > account.Amount)
            {
                MessageBox.Show($"Insufficient funds in account {account.Id}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            account.Amount -= result;
            account.Amount = Math.Round((double)account.Amount, 2, MidpointRounding.AwayFromZero);
            this.depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Withdraw);

            return result;
        }

        public bool BlockAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return false;
            }

            account.Blocking = true;
            this.depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Block);

            return true;
        }

        public bool UnblockAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException();
            }

            var account = this.depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null)
            {
                return false;
            }

            account.Blocking = false;
            this.depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.Unblock);

            return true;
        }

        public void StartCalculate()
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 2);
            this.timer.Tick += this.TimerTick;
            this.timer.Start();
        }

        public void StopCalculate()
        {
            this.timer.Stop();
            this.timer.Tick -= this.TimerTick;
            this.timer = null;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            foreach (var item in this.DepositoryAccounts)
            {
                if (!item.Blocking)
                {
                    if ((item.DepositStatus == DepositStatus.WithoutCapitalization) && this.k == 12)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 100.0)), 2, MidpointRounding.AwayFromZero);
                    }

                    if (item.DepositStatus == DepositStatus.WithCapitalization)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 1200.0)), 2, MidpointRounding.AwayFromZero);
                    }
                }
            }

            if (this.k == 12)
            {
                this.k = 1;
            }
            else
            {
                this.k++;
            }
        }
    }
}
