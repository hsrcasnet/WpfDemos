using System.Collections.ObjectModel;

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

    public class People : Collection<Person>
    {
        public People()
        {
            this.Add(new Person()
            {
                FirstName = "Nelly",
                LastName = "Blinks",
                Age = 26,
                Photo = "nelly.png"
            });
            this.Add(new Person()
            {
                FirstName = "Sam",
                LastName = "Bourts",
                Age = 24,
                Photo = "author.png"
            });
            this.Add(new Person()
            {
                FirstName = "William",
                LastName = "Clinton",
                Age = 66,
                Photo = "author.png"
            });
            this.Add(new Person()
            {
                FirstName = "Jenny",
                LastName = "Miller",
                Age = 16,
                Photo = "author.png"
            });
        }
    }
}