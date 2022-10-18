using System;
using System.ComponentModel;

namespace WpfValueConversion
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private DateTime? retirementDate;
        private bool isLoggedIn;

        public bool IsLoggedIn
        {
            get => this.isLoggedIn;
            set
            {
                this.isLoggedIn = value;
                this.OnPropertyChanged(nameof(this.IsLoggedIn));
            }
        }

        public DateTime? RetirementDate
        {
            get => this.retirementDate;
            set
            {
                this.retirementDate = value;
                this.OnPropertyChanged(nameof(this.RetirementDate));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}