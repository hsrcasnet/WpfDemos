using System.Collections.Generic;

namespace BindToList
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
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