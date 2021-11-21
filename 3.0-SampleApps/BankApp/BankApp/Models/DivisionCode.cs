using System;
using System.Text.Json.Serialization;

namespace BankApp.Models
{

    public class DivisionCode : IDivisionCode
    {
        [JsonPropertyName("Left")]
        public int? Left { get; }

        [JsonPropertyName("Right")]
        public int? Right { get; }

        public DivisionCode(int? left, int? right)
        {
            if (left <= 0)
            {
                throw new ArgumentException("Left must be a positive integer");
            }

            this.Left = left;

            if (right <= 0)
            {
                throw new ArgumentException("Right must be a positive integer");
            }

            this.Right = right;
        }
    }
}
