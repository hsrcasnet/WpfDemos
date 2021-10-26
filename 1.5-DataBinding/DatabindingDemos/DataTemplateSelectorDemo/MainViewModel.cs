using System.Collections.Generic;

namespace DataTemplateSelectorDemo
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Persons = new List<Person>
            {
                new Person { Name = "Emma", Gender = Gender.Female },
                new Person { Name = "Mia", Gender = Gender.Female },
                new Person { Name = "Peter", Gender = Gender.Male },
                new Person { Name = "Marc", Gender = Gender.Male },
            };
        }

        public List<Person> Persons { get; set; }
    }
}