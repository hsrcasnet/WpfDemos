using System.ComponentModel;

namespace DataBindingToObjects
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private int age;
        private string occupation;

        // Each property calls the OnPropertyChanged method
        // when its value changed, and each property that 
        // affects the Person's Description, also calls the 
        // OnPropertyChanged method for the Description property.

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    this.OnPropertyChanged("FirstName");
                    this.OnPropertyChanged("Description");
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    this.OnPropertyChanged(nameof(this.LastName)); // Hint: Use nameof() to get compile-time safe property updates
                    this.OnPropertyChanged(nameof(this.Description));
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.OnPropertyChanged("Age");
                    this.OnPropertyChanged("Description");
                }
            }
        }

        public string Occupation
        {
            get { return this.occupation; }
            set
            {
                if (this.occupation != value)
                {
                    this.occupation = value;
                    this.OnPropertyChanged("Occupation");
                    this.OnPropertyChanged("Description");
                }
            }
        }

        // The Description property is read-only,
        // and is composed of the values of the
        // other properties.
        public string Description
        {
            get
            {
                return $"{this.FirstName} {this.LastName}, {this.Age} ({this.Occupation})";
            }
        }

        #region INotifyPropertyChanged Members

        /// Implement INotifyPropertyChanged to notify the binding
        /// targets when the values of properties change.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                // Raise the PropertyChanged event
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}