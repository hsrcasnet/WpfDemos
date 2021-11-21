using System.Collections.Generic;
using System.Windows.Input;
using BankApp.Commands;
using BankApp.Enums;
using BankApp.Models;
using BankApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.ViewModels
{

    public class MainUserControlViewModel : BaseClassViewModelINPC
    {
        private readonly DepartmentsManager departmentsManager;
        private readonly BankCustomersManager bankCustomersManager;
        private readonly ProcessingOfDepositoryAccounts processingOfDepositoryAccounts;

        private readonly BankCustomerDialogService bankCustomerDialog;
        private Department selectedDepartment;
        private BankCustomer selectedBankCustomer;
        private DepositoryAccount selectedDepositoryAccount;

        private ICommand editDataBankCustomer = default!;
        private ICommand createNewDepositoryAccount = default!;
        private ICommand deleteDepositoryAccount = default!;
        private ICommand createNewBankCustomer = default!;
        private ICommand deleteBankCustomer = default!;
        private ICommand editDepositoryAccount = default!;
        private ICommand combiningDepositoryAccounts = default!;
        private ICommand transferToDepositoryAccount = default!;
        private ICommand withdrawFromDepositoryAccount = default!;

        private BankCustomerInfoDialog BankCustomerInfoDialog => App.Host.Services.GetRequiredService<BankCustomerInfoDialog>();

        public MainUserControlViewModel(
            BankCustomersManager bankCustomersManager,
            DepartmentsManager departmentsManager,
            BankCustomerDialogService bankCustomerDialog,
            ProcessingOfDepositoryAccounts processingOfDepositoryAccounts)
        {
            this.departmentsManager = departmentsManager;
            this.bankCustomersManager = bankCustomersManager;
            this.bankCustomerDialog = bankCustomerDialog;
            this.processingOfDepositoryAccounts = processingOfDepositoryAccounts;

            this.bankCustomersManager.ManagerEvent += this.BankCustomersManagerEvent;
            this.processingOfDepositoryAccounts.ProcessingOfAccountsEvent += this.OnProcessingOfAccountsEvent;
            this.processingOfDepositoryAccounts.StartCalculate();
        }

        public IList<IDepartment> Departments => this.departmentsManager.Departments;

        public IList<IBankCustomer> BankCustomers => this.bankCustomersManager.BankCustomers;

        public Department SelectedDepartment
        {
            get => this.selectedDepartment;
            set => this.Set(ref this.selectedDepartment, value);
        }

        public BankCustomer SelectedBankCustomer
        {
            get => this.selectedBankCustomer;
            set => this.Set(ref this.selectedBankCustomer, value);
        }

        public DepositoryAccount SelectedDepositoryAccount
        {
            get => this.selectedDepositoryAccount;
            set => this.Set(ref this.selectedDepositoryAccount, value);
        }

        public ICommand CreateNewBankCustomer
        {
            get => this.createNewBankCustomer ??= new RelayCommand((obj) =>
            {
                var department = (Department)obj;
                if (department is null)
                {
                    return;
                }

                var bankCustomer = this.bankCustomerDialog.Create(department.StatusDepartment);
                if (bankCustomer is null)
                {
                    return;
                }

                this.bankCustomersManager.Create(bankCustomer, department);
            }, (obj) => obj is Department);
        }

        public ICommand DeleteBankCustomer
        {
            get => this.deleteBankCustomer ??= new RelayCommand((obj) =>
            {
                var department = this.SelectedDepartment;
                var bankCustomer = (BankCustomer)obj;

                if (department is null || bankCustomer is null)
                {
                    return;
                }

                this.bankCustomersManager.Delete(bankCustomer, department);
            }, (obj) => obj is BankCustomer);
        }

        public ICommand EditDataBankCustomer
        {
            get => this.editDataBankCustomer ??= new RelayCommand((obj) =>
            {
                var bankCustomer = (BankCustomer)obj;
                if (bankCustomer is null)
                {
                    return;
                }

                var tempBankCustomer = this.bankCustomerDialog.Edit(bankCustomer);
                if (tempBankCustomer is null)
                {
                    return;
                }

                this.bankCustomersManager.Update(tempBankCustomer);
            }, (obj) => obj is BankCustomer);
        }

        public ICommand CreateNewDepositoryAccount
        {
            get => this.createNewDepositoryAccount ??= new RelayCommand((obj) =>
            {
                if (obj is BankCustomer bankCustomer)
                {
                    this.processingOfDepositoryAccounts.OpenAccount(bankCustomer);
                }
            }, (obj) => obj is BankCustomer);
        }

        public ICommand DeleteDepositoryAccount
        {
            get => this.deleteDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.processingOfDepositoryAccounts.CloseAccount(this.SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        public ICommand EditDepositoryAccount
        {
            get => this.editDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.processingOfDepositoryAccounts.EditAccount(this.SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        public ICommand CombiningDepositoryAccounts
        {
            get => this.combiningDepositoryAccounts ??= new RelayCommand((obj) =>
            {
                this.processingOfDepositoryAccounts.CombiningAccounts(this.SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        public ICommand TransferToDepositoryAccount
        {
            get => this.transferToDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.processingOfDepositoryAccounts.TransferToAccount(this.SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        public ICommand WithdrawFromDepositoryAccount
        {
            get => this.withdrawFromDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.processingOfDepositoryAccounts.WithdrawFromAccount(this.SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        private void BankCustomersManagerEvent(object sender, ManagerArgs args)
        {
            this.BankCustomerInfoDialog.Dialog((IBankCustomer)sender);
        }

        private void OnProcessingOfAccountsEvent(object sender, ProcessingOfAccountsArgs args)
        {
        }
    }
}
