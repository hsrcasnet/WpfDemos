using System.ComponentModel;

namespace SortingFilteringGrouping
{
    public class Customer : INotifyPropertyChanged
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
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                this.age = value;
                this.OnPropertyChanged("Age");
            }
        }

        public string Photo { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}, Age: {this.Age}";
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}