using System.Collections.Generic;

namespace BindToListSimple
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Photo { get; set; }

        // Demo: Uncomment this code to show the effect of ToString if no DataTemplate is applied
        //public override string ToString()
        //{
        //    return string.Format("{0} {1}", FirstName, LastName);
        //}
    }

    public class PeopleFactory
    {
        private readonly List<Person> people = new List<Person>();

        public PeopleFactory()
        {
            this.people.Add(new Person()
            {
                FirstName = "Nelly",
                LastName = "Blinks",
                Age = 26,
                Photo = "nelly.png"
            });
            this.people.Add(new Person()
            {
                FirstName = "Sam",
                LastName = "Bourts",
                Age = 24,
                Photo = "author.png"
            });
            this.people.Add(new Person()
            {
                FirstName = "Jim",
                LastName = "Miller",
                Age = 45,
                Photo = "author.png"
            });
        }

        public IEnumerable<Person> GetPeople()
        {
            return this.people;
        }
    }
}