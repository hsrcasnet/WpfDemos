using System.Collections.Generic;
using BankApp.Enums;

namespace BankApp.Models
{
    public interface IBankCustomer : IElement
    {
        Passport Passport { get; set; }

        Status ClientStatus { get; set; }

        Reliability Reliability { get; set; }

        string PhoneNumber { get; set; }

        string Email { get; set; }

        string Description { get; set; }

        IList<IDepositoryAccount> DepositoryAccounts { get; set; }

        bool Equals(IBankCustomer obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            var key = true;

            if (this.DepositoryAccounts == null && obj.DepositoryAccounts != null ||
               this.DepositoryAccounts != null && obj.DepositoryAccounts == null)
            {
                key = false;
            }

            if (this.DepositoryAccounts != null && obj.DepositoryAccounts != null && key)
            {
                if (this.DepositoryAccounts.Count == obj.DepositoryAccounts.Count)
                {
                    for (var i = 0; i < this.DepositoryAccounts.Count && key; i++)
                    {
                        key = key && this.DepositoryAccounts[i].Equals(obj.DepositoryAccounts[i]);
                    }
                }
                else
                {
                    key = false;
                }
            }

            if (!key)
            {
                return false;
            }

            return this.Id == obj.Id &&
                   this.Passport.Equals(obj.Passport) &&
                   this.ClientStatus == obj.ClientStatus &&
                   this.Reliability == obj.Reliability &&
                   this.PhoneNumber == obj.PhoneNumber &&
                   this.Email == obj.Email;
        }
    }
}
