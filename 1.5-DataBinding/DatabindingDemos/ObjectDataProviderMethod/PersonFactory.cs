namespace ObjectDataProviderMethod
{
    public class PersonFactory
    {
        public Person GetThePerson()
        {
            return new Person() { FirstName = "Anna", LastName = "Schmid", Age = 22 };
        }
    }
}