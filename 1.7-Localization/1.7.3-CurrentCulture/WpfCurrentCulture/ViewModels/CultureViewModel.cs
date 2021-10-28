using System.Globalization;
using System.Threading;

namespace WpfCurrentCulture.ViewModels
{
    public class CultureViewModel : ViewModelBase
    {
        private readonly CultureInfo originalCurrentCulture;
        private readonly CultureInfo originalCurrentUICulture;

        private CultureInfo currentCulture;
        private CultureInfo currentUiCulture;

        public CultureViewModel()
        {
            this.originalCurrentCulture = Thread.CurrentThread.CurrentCulture;
            this.originalCurrentUICulture = Thread.CurrentThread.CurrentUICulture;

            this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
            this.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
        }

        public CultureInfo CurrentCulture
        {
            get => this.currentCulture;
            set
            {
                if (this.currentCulture != value)
                {
                    this.currentCulture = value;
                    this.OnPropertyChanged(nameof(this.CurrentCulture));
                }
            }
        }

        public CultureInfo CurrentUICulture
        {
            get => this.currentUiCulture;
            set
            {
                if (this.currentUiCulture != value)
                {
                    this.currentUiCulture = value;
                    this.OnPropertyChanged(nameof(this.CurrentUICulture));
                }
            }
        }

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