using System;
using System.Globalization;
using System.Threading;

namespace WpfCurrentCulture.ViewModels
{
    public class CultureViewModel : ViewModelBase
    {
        private readonly CultureInfo originalCurrentCulture;
        private readonly CultureInfo originalCurrentUICulture;

        public CultureViewModel()
        {
            this.originalCurrentCulture = Thread.CurrentThread.CurrentCulture;
            this.originalCurrentUICulture = Thread.CurrentThread.CurrentUICulture;

            this.DateTime1 = new DateTime(2000, 1, 2, 9, 10, 0, DateTimeKind.Local);
            this.DateTime2 = new DateTime(2000, 1, 2, 17, 0, 0, DateTimeKind.Local);
            this.Decimal = 1222333444.555M;
        }

        public CultureInfo CurrentCulture
        {
            get => Thread.CurrentThread.CurrentCulture;
            set
            {
                if (Thread.CurrentThread.CurrentCulture != value)
                {
                    Thread.CurrentThread.CurrentCulture = value;

                    this.OnPropertyChanged("");
                }
            }
        }

        public CultureInfo CurrentUICulture
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (Thread.CurrentThread.CurrentUICulture != value)
                {
                    Thread.CurrentThread.CurrentUICulture = value;

                    this.OnPropertyChanged(""); // Update all properties
                }
            }
        }

        public DateTime DateTime1 { get; set; }

        public DateTime DateTime2 { get; set; }

        public decimal Decimal { get; set; }

        public void ResetCurrentCulture()
        {
            this.CurrentCulture = this.originalCurrentCulture;
        }

        public void ResetCurrentUICulture()
        {
            this.CurrentUICulture = this.originalCurrentUICulture;
        }
    }
}