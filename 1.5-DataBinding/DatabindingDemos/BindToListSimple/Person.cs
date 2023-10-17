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
}