using System;

namespace WpfObservableCollection.ViewModels
{
    internal static class CustomerTestData
    {
        private static readonly Random Rng = new Random();

        private static readonly string[] FirstNames = {
            "Mahesh",
            "Jeff",
            "Dave",
            "Allen",
            "Monica",
            "Henry",
            "Raj",
            "Mark",
            "Rose",
            "Mike"
        };

        private static readonly string[] LastNames = {
            "Chand",
            "Prosise",
            "McCarter",
            "O'neill",
            "Rathbun",
            "He",
            "Kumar",
            "Prime",
            "Tracey",
            "Crown"
        };

        internal static Customer GetNext()
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = FirstNames[Rng.Next(FirstNames.Length)],
                LastName = LastNames[Rng.Next(LastNames.Length)],
            };
        }

    }
}
