using System.ComponentModel;

namespace BindToList2
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                this.firstName = value;
                this.FirePropertyChanged(nameof(this.FirstName));
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
                this.FirePropertyChanged(nameof(this.LastName));
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                this.age = value;
                this.FirePropertyChanged(nameof(this.Age));
            }
        }

        public string Photo { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        private void FirePropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}