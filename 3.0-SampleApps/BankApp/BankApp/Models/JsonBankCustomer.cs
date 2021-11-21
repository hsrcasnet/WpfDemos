using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using BankApp.Enums;

namespace BankApp.Models
{

    public class JsonBankCustomer
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Blocking")]
        public bool Blocking { get; set; }

        [JsonPropertyName("Passport")]
        public JsonPassport Passport { get; set; }

        [JsonPropertyName("ClientStatus")]
        public Status ClientStatus { get; set; }

        [JsonPropertyName("Reliability")]
        public Reliability Reliability { get; set; }

        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("DepositoryAccounts")]
        public ObservableCollection<DepositoryAccount> DepositoryAccounts { get; set; }
    }
}
