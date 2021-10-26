using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace WpfObservableCollection
{
    public class ShoppingMall : IDisposable
    {
        private readonly DispatcherTimer timer;

        public ShoppingMall()
        {
            this.Customers = new ObservableCollection<Customer>();

            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += this.OnTimerTick;
            this.timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            this.Customers.Add(new Customer { Name = $"Customer {Guid.NewGuid():B}" });

            if (this.Customers.Count >= 10)
            {
                this.Customers.Clear();
            }
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public void Dispose()
        {
            this.timer.Tick -= this.OnTimerTick;
        }
    }
}