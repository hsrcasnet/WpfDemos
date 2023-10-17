using System.Collections.Generic;

namespace BindToListSimple
{
    public static class PersonFactory
    {
        public static IEnumerable<Person> GetPersons()
        {
            yield return new Person()
            {
                FirstName = "Nelly",
                LastName = "Blinks",
                Age = 26,
                Photo = "nelly.png"
            };
            yield return new Person()
            {
                FirstName = "Sam",
                LastName = "Bourts",
                Age = 24,
                Photo = "author.png"
            };
            yield return new Person()
            {
                FirstName = "Jim",
                LastName = "Miller",
                Age = 45,
                Photo = "author.png"
            };
        }
    }
}