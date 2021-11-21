using System;
using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services
{

    public class DepositoryAccountsManager
    {
        private readonly DepositoryAccountRepository depositoryAccountRepository;
        private readonly BankCustomersManager bankCustomersManager;

        public DepositoryAccountsManager(DepositoryAccountRepository depositoryAccountRepository, BankCustomersManager bankCustomersManager)
        {
            this.bankCustomersManager = bankCustomersManager;
            this.depositoryAccountRepository = depositoryAccountRepository;
        }

        public IList<IDepositoryAccount> DepositoryAccounts => this.depositoryAccountRepository.GetAll();

        public void Update(IDepositoryAccount depositoryAccount)
        {
            this.depositoryAccountRepository.Update(depositoryAccount.Id, depositoryAccount);
        }

        public bool Create(IDepositoryAccount depositoryAccount,
                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException(nameof(bankCustomer), "Bank customer must not be null");
            }

            if (depositoryAccount is null)
            {
                throw new ArgumentNullException(nameof(depositoryAccount), "Deposit must not be null");
            }

            var selectedBankCustomer = this.bankCustomersManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null)
            {
                return false;
            }

            bankCustomer.DepositoryAccounts.Add(depositoryAccount);
            this.depositoryAccountRepository.Add(depositoryAccount);

            return true;
        }

        public bool Delete(IDepositoryAccount depositoryAccount, IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException(nameof(bankCustomer), "Bank customer must not be null");
            }

            if (depositoryAccount is null)
            {
                throw new ArgumentNullException(nameof(depositoryAccount), "Deposit must not be null");
            }

            var selectedBankCustomer = this.bankCustomersManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null)
            {
                return false;
            }

            if (bankCustomer.DepositoryAccounts.Remove(depositoryAccount))
            {
                this.depositoryAccountRepository.Remove(depositoryAccount);
                return true;
            }

            return false;
        }

        public IDepositoryAccount Get(int id) => this.depositoryAccountRepository.Get(id);
    }
}
