using System.ComponentModel;

namespace DataBindingToObjects
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private int age;
        private string occupation;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;

                    // Raise PropertyChanged event for all bindings to "FirstName" and "Description"
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

                    // Hint: Use nameof() to get compile-time safe property updates
                    this.OnPropertyChanged(nameof(this.LastName));
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
                    this.OnPropertyChanged(nameof(this.Age));
                    this.OnPropertyChanged(nameof(this.Description));
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
                    this.OnPropertyChanged(nameof(this.Occupation));
                    this.OnPropertyChanged(nameof(this.Description));
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
            // Raise the PropertyChanged event
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}