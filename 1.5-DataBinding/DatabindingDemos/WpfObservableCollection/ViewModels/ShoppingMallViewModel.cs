using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using WpfObservableCollection.ViewModels;

namespace WpfObservableCollection
{
    public class ShoppingMall : IDisposable
    {

        private readonly DispatcherTimer timer;

        public ShoppingMall()
        {
            this.Customers = new ObservableCollection<CustomerViewModel>();

            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += this.OnTimerTick;
            this.timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var newCustomer = CustomerTestData.GetNext();
            var newCustomerViewModel = new CustomerViewModel(newCustomer);
            this.Customers.Add(newCustomerViewModel);

            if (this.Customers.Count >= 10)
            {
                this.Customers.Clear();
            }

            // Demo: How can we update the Name property
            // of an existing customer?
            //var lastCustomer = this.Customers.Last();
            //lastCustomer.Name = $"Customer {Guid.NewGuid():B} (LAST)";

        }

        public ObservableCollection<CustomerViewModel> Customers { get; }

        public void Dispose()
        {
            this.timer.Tick -= this.OnTimerTick;
        }
    }
}