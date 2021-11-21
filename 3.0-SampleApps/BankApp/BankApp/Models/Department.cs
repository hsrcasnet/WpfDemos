using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BankApp.Enums;

namespace BankApp.Models
{
    public class Department : IDepartment
    {
        public Department(int id, string name, Status statusDepartment)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name must not be null or empty");
            }

            if (id < 0)
            {
                throw new ArgumentException("id must be a positive integer");
            }

            this.Id = id;
            this.Name = name;
            this.StatusDepartment = statusDepartment;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Status StatusDepartment { get; set; }

        public IList<IBankCustomer> BankCustomers { get; set; } = new ObservableCollection<IBankCustomer>();
    }
}
