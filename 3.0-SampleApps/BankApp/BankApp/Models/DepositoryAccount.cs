using System;
using System.Text.Json.Serialization;
using BankApp.Enums;

namespace BankApp.Models
{
    public class DepositoryAccount : BaseClassModelINPC, IDepositoryAccount
    {
        private int id = 0;
        private bool blocking = false;
        private DepositStatus depositStatus = DepositStatus.WithCapitalization;
        private double? amount = 0;
        private double? interestRate = 0;

        public DepositoryAccount(int id, double? amount, double? interestRate, DepositStatus depositStatus)
        {
            this.Id = id;
            this.Amount = amount;
            this.InterestRate = interestRate;
            this.DepositStatus = depositStatus;
        }

        [JsonPropertyName("Id")]
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

        [JsonPropertyName("Blocking")]
        public bool Blocking
        {
            get => this.blocking;
            set => this.Set(ref this.blocking, value);
        }

        [JsonPropertyName("DepositStatus")]
        public DepositStatus DepositStatus
        {
            get => this.depositStatus;
            set => this.Set(ref this.depositStatus, value);
        }

        [JsonPropertyName("Amount")]
        public double? Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount must be a positive number");
                }

                this.Set(ref this.amount, value);
            }
        }

        [JsonPropertyName("InterestRate")]
        public double? InterestRate
        {
            get => this.interestRate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("InterestRate must be a positive number");
                }

                this.Set(ref this.interestRate, value);
            }
        }

        public AccountStatus AccountStatus => AccountStatus.Deposit;

    }
}
