using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BankApp.Enums;

namespace BankApp.Models
{
    public static class TestData
    {
        public static IList<IDepartment> Departments { get; set; } = CreateDepartments();

        public static IList<IBankCustomer> BankCustomers { get; set; } = CreateBankCustomers(Departments);

        public static IList<IDepositoryAccount> DepositoryAccounts { get; set; } = CreateDepositoryAccounts(BankCustomers);

        public static IList<IDepartment> CreateDepartments()
        {
            var departments = new ObservableCollection<IDepartment>
            {
                new Department(1, $"Department { 1 }", Status.Usual),
                new Department(2, $"Department { 2 }", Status.Vip),
                new Department(3, $"Department { 3 }", Status.Juridical)
            };

            return departments;
        }

        private static IList<IBankCustomer> CreateBankCustomers(IList<IDepartment> departments)
        {
            var index = 1;
            var gender = Gender.Male;
            var reliability = Reliability.Low;

            foreach (var item in departments)
            {
                for (var i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        gender = Gender.Female;
                        reliability = Reliability.Low;
                    }
                    else
                    {
                        gender = Gender.Male;
                        reliability = Reliability.Medium;
                    }

                    var address = new Address(DateTime.Today, $"Region {index}", $"City {index}", $"Street {index}", 100 + index);
                    var person = new Person($"Lastname {index}", $"Name {index}", gender, DateTime.Today, $"Place of Birth {index}", address);
                    var divisionCode = new DivisionCode(200 + index, 300 + index);
                    var pasport = new Passport(111, 222222, $"Place of Issue {index}", DateTime.Today, divisionCode, person);

                    var bankCustomer = new BankCustomer(index, pasport, item.StatusDepartment, reliability, $"+4142000000");

                    item.BankCustomers.Add(bankCustomer);
                    index++;
                }
            }

            return departments.SelectMany(d => d.BankCustomers).ToList();
        }

        private static IList<IDepositoryAccount> CreateDepositoryAccounts(IList<IBankCustomer> bankCustomers)
        {
            var index = 1;
            var key = false;
            DepositoryAccount bankAccount;

            foreach (var item in bankCustomers)
            {
                for (var i = 0; i < 4; i++)
                {
                    if (key)
                    {
                        bankAccount = new DepositoryAccount(index, 1000, InterestRate(item.ClientStatus), DepositStatus.WithoutCapitalization);
                        key = !key;
                    }
                    else
                    {
                        bankAccount = new DepositoryAccount(index, 2000, InterestRate(item.ClientStatus), DepositStatus.WithCapitalization);
                        key = !key;
                    }

                    item.DepositoryAccounts.Add(bankAccount);
                    index++;
                }
            }

            return bankCustomers.SelectMany(d => d.DepositoryAccounts).ToList();
        }

        private static double InterestRate(Status status)
        {
            if (status == Status.Vip)
            {
                return 10;
            }

            if (status == Status.Juridical)
            {
                return 8;
            }

            return 12;
        }
    }
}
