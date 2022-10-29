using System.ComponentModel;

namespace WpfObservableCollection.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private string name;

        public CustomerViewModel(Customer customer)
        {
            this.Name = $"{customer.FirstName} {customer.LastName}";;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
