using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfInputValidation.ViewModels
{
    public class CustomerViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, ICollection<string>> validationErrors = new Dictionary<string, ICollection<string>>();

        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                this.ValidateProperty(nameof(this.FirstName));
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                this.ValidateProperty(nameof(this.LastName));
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("No negative values allowed");
                }

                this.age = value;
                this.ValidateProperty(nameof(this.Age));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            var propertyErrors = this.validationErrors.GetValueOrDefault(propertyName);
            return propertyErrors;
        }

        public bool HasErrors => this.validationErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void ValidateProperty(string propertyName)
        {
            var propertyErrors = new List<string>();

            /* Demo code only!
               This is the place to call a backend service asynchronously
               or to run a validation strategy */
            if (propertyName == nameof(this.FirstName))
            {
                if (string.IsNullOrEmpty(this.FirstName))
                {
                    propertyErrors.Add("Please enter a First Name");
                    propertyErrors.Add("Properties can have multiple validation errors");
                }
            }

            var isValid = !propertyErrors.Any();
            if (!isValid)
            {
                /* Update the collection in the dictionary returned by the GetErrors method */
                this.validationErrors[propertyName] = propertyErrors;

                /* Raise event to tell WPF to execute the GetErrors method */
                this.OnErrorsChanged(propertyName);
            }
            else if (this.validationErrors.ContainsKey(propertyName))
            {
                /* Remove all errors for this property */
                this.validationErrors.Remove(propertyName);

                /* Raise event to tell WPF to execute the GetErrors method */
                this.OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}


