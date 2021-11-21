using System;
using System.Text.Json.Serialization;

namespace BankApp.Models
{
    public class JsonPassport
    {
        [JsonPropertyName("Number")]
        public long? Number { get; set; }

        [JsonPropertyName("Series")]
        public long? Series { get; set; }

        [JsonPropertyName("PlaceOfIssue")]
        public string PlaceOfIssue { get; set; }

        [JsonPropertyName("DateOfIssue")]
        public DateTime? DateOfIssue { get; set; }

        [JsonPropertyName("DivisionCode")]
        public DivisionCode DivisionCode { get; set; }

        [JsonPropertyName("Holder")]
        public JsonPerson Holder { get; set; }
    }
}
