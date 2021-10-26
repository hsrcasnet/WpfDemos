using System.Collections.Generic;

namespace SortingFilteringGrouping
{
    public class CustomersFactory
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer
            {
                FirstName = "Nelly",
                LastName = "Blinks",
                Age = 26,
                Photo = "nelly.png"
            };
            yield return new Customer
            {
                FirstName = "Albert",
                LastName = "Bourts",
                Age = 24,
                Photo = "author.png"
            };
            yield return new Customer
            {
                FirstName = "Berta",
                LastName = "Miller",
                Age = 24,
                Photo = "author.png"
            };
            yield return new Customer
            {
                FirstName = "Axel",
                LastName = "Schweiss",
                Age = 16,
                Photo = "axel.png"
            };
        }
    }
}