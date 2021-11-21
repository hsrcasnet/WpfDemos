using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using BankApp.Enums;

namespace BankApp.Models
{

    public class JsonDepartment
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("StatusDepartment")]
        public Status StatusDepartment { get; set; }

        [JsonPropertyName("BankCustomers")]
        public ObservableCollection<JsonBankCustomer> BankCustomers { get; set; }
    }
}
