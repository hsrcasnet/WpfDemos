using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using WpfMultilingual.Localization;

namespace WpfMultilingual.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITranslationManager translationManager;

        public MainViewModel(ITranslationManager translationManager)
        {
            this.translationManager = translationManager;
            this.Language = CultureInfo.CurrentUICulture;
        }

        public CultureInfo Language
        {
            get => this.translationManager.CurrentLanguage;
            set
            {
                this.translationManager.CurrentLanguage = value;
                this.OnPropertyChanged(nameof(this.Language));
                this.OnPropertyChanged(nameof(this.CurrentCulture));
                this.OnPropertyChanged(nameof(this.CurrentUICulture));
            }
        }

        public CultureInfo CurrentCulture
        {
            get => Thread.CurrentThread.CurrentCulture;
        }

        public CultureInfo CurrentUICulture
        {
            get => Thread.CurrentThread.CurrentUICulture;
        }

        public IEnumerable<CultureInfo> Languages => this.translationManager.Languages;
    }
}