using System.Collections.Generic;
using BankApp.Enums;

namespace BankApp.Models
{

    public interface IDepartment : IEntity
    {
        string Name { get; set; }

        Status StatusDepartment { get; set; }

        IList<IBankCustomer> BankCustomers { get; set; }
    }
}
