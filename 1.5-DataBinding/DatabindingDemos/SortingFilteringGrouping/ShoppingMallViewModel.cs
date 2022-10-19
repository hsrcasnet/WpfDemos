using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace SortingFilteringGrouping
{
    public class ShoppingMallViewModel
    {
        public ObservableCollection<Customer> Customers { get; }

        // CustomerView is the C# code representation of an ICollectionView
        // just as customerCollectionViewSource is in XAML.
        public ICollectionView CustomerView { get; }

        public ShoppingMallViewModel()
        {
            // Initialize ObservableCollection with customers 
            var customers = CustomersFactory.GetCustomers().ToList();
            this.Customers = new ObservableCollection<Customer>(customers);

            this.CustomerView = CollectionViewSource.GetDefaultView(this.Customers);

            // Sorting
            this.CustomerView.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            this.CustomerView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
            this.CustomerView.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));

            // Grouping
            this.CustomerView.GroupDescriptions.Add(new PropertyGroupDescription("Age"));

            // Filtering
            this.CustomerView.Filter = obj =>
            {
                var isMature = false;
                if (obj is Customer customer)
                {
                    isMature = customer.Age >= 18;
                }

                return isMature;
            };
        }
    }
}