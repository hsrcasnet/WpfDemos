using System;
using System.Collections.Generic;
using BankApp.Enums;
using BankApp.Infrastructure;
using BankApp.Models;

namespace BankApp.Services
{
    public class BankCustomersManager
    {
        private readonly BankCustomerRepository bankCustomerRepository;
        private readonly DepartmentsManager departmentsManager;

        public BankCustomersManager(BankCustomerRepository bankCustomerRepository, DepartmentsManager departmentsManager)
        {
            this.bankCustomerRepository = bankCustomerRepository;
            this.departmentsManager = departmentsManager;
        }

        public event ManagerEventHandler ManagerEvent;

        public IList<IBankCustomer> BankCustomers => this.bankCustomerRepository.GetAll();

        public void Update(IBankCustomer bankCustomer)
        {
            this.bankCustomerRepository.Update(bankCustomer.Id, bankCustomer);
            ManagerEvent?.Invoke(bankCustomer, ManagerArgs.Update);
        }

        public bool Create(IBankCustomer bankCustomer, IDepartment department)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException(nameof(bankCustomer), "Bank customer must not be null");
            }

            if (department is null)
            {
                throw new ArgumentNullException(nameof(department), "Department must not be null");
            }

            var selectedDepartment = this.departmentsManager.Get(department.Name);
            if (selectedDepartment is null)
            {
                return false;
            }

            department.BankCustomers.Add(bankCustomer);
            this.bankCustomerRepository.Add(bankCustomer);
            ManagerEvent?.Invoke(bankCustomer, ManagerArgs.Create);

            return true;
        }

        public bool Delete(IBankCustomer bankCustomer, IDepartment department)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException(nameof(bankCustomer), "Bank customer must not be null");
            }

            if (department is null)
            {
                throw new ArgumentNullException(nameof(department), "Department must not be null");
            }

            var selectedDepartment = this.departmentsManager.Get(department.Name);
            if (selectedDepartment is null)
            {
                return false;
            }

            if (department.BankCustomers.Remove(bankCustomer) &&
               this.bankCustomerRepository.Remove(bankCustomer))
            {
                ManagerEvent?.Invoke(bankCustomer, ManagerArgs.Delete);
                return true;
            }

            return false;
        }

        public IBankCustomer Get(int id)
        {
            return this.bankCustomerRepository.Get(id);
        }
    }
}
