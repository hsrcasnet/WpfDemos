namespace WpfObservableCollection
{
    public class Customer
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}