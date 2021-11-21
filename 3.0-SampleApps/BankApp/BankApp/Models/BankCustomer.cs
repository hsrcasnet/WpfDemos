using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BankApp.Enums;

namespace BankApp.Models
{
    public class BankCustomer : BaseClassModelINPC, IBankCustomer
    {
        private int id = 0;
        private bool blocking;
        private Passport passport;
        private Status clientStatus = Status.Usual;
        private Reliability reliability = Reliability.Low;
        private string phoneNumber;
        private string email;
        private string description;

        public int Id
        {
            get => this.id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be a positive integer");
                }

                this.Set(ref this.id, value);
            }
        }

        public bool Blocking
        {
            get => this.blocking;
            set => this.Set(ref this.blocking, value);
        }

        public Passport Passport
        {
            get => this.passport;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Passport must not be null");
                }

                this.Set(ref this.passport, value);
            }
        }

        public Status ClientStatus
        {
            get => this.clientStatus;
            set => this.Set(ref this.clientStatus, value);
        }

        public Reliability Reliability
        {
            get => this.reliability;
            set => this.Set(ref this.reliability, value);
        }

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set => this.Set(ref this.phoneNumber, value);
        }

        public string Email
        {
            get => this.email;
            set => this.Set(ref this.email, value);
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        public IList<IDepositoryAccount> DepositoryAccounts { get; set; } = new ObservableCollection<IDepositoryAccount>();

        public BankCustomer(int id,
                            Passport passport,
                            Status clientStatus,
                            Reliability reliability,
                            string phoneNumber = null,
                            string email = null)
        {
            this.Id = id;
            this.Passport = passport;
            this.ClientStatus = clientStatus;
            this.Reliability = reliability;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
    }
}
