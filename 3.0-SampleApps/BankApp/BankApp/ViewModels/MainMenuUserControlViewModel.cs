using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BankApp.Commands;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.ViewModels
{
    public class MainMenuUserControlViewModel : BaseClassViewModelINPC
    {
        private readonly MainUserControlViewModel mainUserControlViewModel;
        private readonly FileDialog fileDialog;
        private readonly DepartmentRepository departmentRepository;
        private readonly BankCustomerRepository bankCustomerRepository;
        private readonly DepositoryAccountRepository depositoryAccountRepository;

        private ICommand createNewBankCustomer = default!;
        private ICommand deleteBankCustomer = default!;

        public MainMenuUserControlViewModel(
            MainUserControlViewModel mainUserControlViewModel,
            FileDialog fileDialog,
            DepartmentRepository departmentRepository,
            BankCustomerRepository bankCustomerRepository,
            DepositoryAccountRepository depositoryAccountRepository)
        {
            this.mainUserControlViewModel = mainUserControlViewModel;
            this.fileDialog = fileDialog;
            this.departmentRepository = departmentRepository;
            this.bankCustomerRepository = bankCustomerRepository;
            this.depositoryAccountRepository = depositoryAccountRepository;

            this.Departments = this.mainUserControlViewModel.Departments;
        }

        public IList<IDepartment> Departments { get; set; }

        public IList<IBankCustomer> BankCustomers { get; set; }

        public IList<IDepositoryAccount> DepositoryAccounts { get; set; }

        private ICommand saveToFile = default!;
        public ICommand SaveToFile
        {
            get => this.saveToFile ??= new RelayCommand((obj) =>
            {
                this.fileDialog.SaveFileDialog(this.Departments);
            }, (obj) => this.mainUserControlViewModel.Departments != null);
        }

        private ICommand openFile = default!;
        public ICommand OpenFile
        {
            get => this.openFile ??= new RelayCommand((obj) =>
            {
                var departments = this.fileDialog.OpenFileDialog();

                if (departments != null)
                {
                    this.Departments = departments;
                    this.departmentRepository.SetAll(this.Departments);

                    var bankCustomers = this.Departments.SelectMany(d => d.BankCustomers).ToList();

                    if (bankCustomers != null)
                    {
                        this.BankCustomers = bankCustomers;
                        this.bankCustomerRepository.SetAll(this.BankCustomers);

                        var depositoryAccounts = this.BankCustomers.SelectMany(d => d.DepositoryAccounts).ToList();

                        if (depositoryAccounts != null)
                        {
                            this.DepositoryAccounts = depositoryAccounts;
                            this.depositoryAccountRepository.SetAll(this.DepositoryAccounts);
                        }
                    }
                }
            });
        }

        public ICommand CreateNewBankCustomer
        {
            get => this.createNewBankCustomer ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.CreateNewBankCustomer.Execute(this.mainUserControlViewModel.SelectedDepartment);
            }, (obj) => this.mainUserControlViewModel.SelectedDepartment != null);
        }

        public ICommand DeleteBankCustomer
        {
            get => this.deleteBankCustomer ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.DeleteBankCustomer.Execute(this.mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => this.mainUserControlViewModel.SelectedBankCustomer != null);
        }

        private ICommand editDataBankCustomer = default!;
        public ICommand EditDataBankCustomer
        {
            get => this.editDataBankCustomer ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.EditDataBankCustomer.Execute(this.mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => this.mainUserControlViewModel.SelectedBankCustomer != null);
        }

        private ICommand createNewDepositoryAccount = default!;
        public ICommand CreateNewDepositoryAccount
        {
            get => this.createNewDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.CreateNewDepositoryAccount.Execute(this.mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => this.mainUserControlViewModel.SelectedBankCustomer != null);
        }

        private ICommand deleteDepositoryAccount = default!;
        public ICommand DeleteDepositoryAccount
        {
            get => this.deleteDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.DeleteDepositoryAccount.Execute(this.mainUserControlViewModel.SelectedDepositoryAccount);
            }, (obj) => this.mainUserControlViewModel.SelectedDepositoryAccount != null);
        }

        private ICommand editDepositoryAccount = default!;
        public ICommand EditDepositoryAccount
        {
            get => this.editDepositoryAccount ??= new RelayCommand((obj) =>
            {
                this.mainUserControlViewModel.EditDepositoryAccount.Execute(this.mainUserControlViewModel.SelectedDepositoryAccount);
            }, (obj) => this.mainUserControlViewModel.SelectedDepositoryAccount != null);
        }
    }
}
