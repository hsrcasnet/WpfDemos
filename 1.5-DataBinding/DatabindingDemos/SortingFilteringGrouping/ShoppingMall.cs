using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace SortingFilteringGrouping
{
    public class ShoppingMall
    {
        public ObservableCollection<Customer> Customers { get; }

        // CustomerView is has basically the same purpose as customerCollectionViewSource (XAML)
        public ICollectionView CustomerView { get; }

        public ShoppingMall()
        {
            this.Customers = new ObservableCollection<Customer>(CustomersFactory.GetCustomers());
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