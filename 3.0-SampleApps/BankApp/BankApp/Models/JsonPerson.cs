using System;
using System.Text.Json.Serialization;
using BankApp.Enums;

namespace BankApp.Models
{
    public class JsonPerson
    {
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }

        [JsonPropertyName("PlaceOfBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("PlaceOfResidence")]
        public Address PlaceOfResidence { get; set; }

        [JsonPropertyName("PlaceOfRegistration")]
        public Address PlaceOfRegistration { get; set; }
    }
}
