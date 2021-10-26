using System.Collections.Generic;
using System.Globalization;
using WpfMultilingual.Localization;

namespace WpfMultilingual
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
                this.OnPropertyChanged(nameof(Language));
            }
        }

        public IEnumerable<CultureInfo> Languages => this.translationManager.Languages;
    }
}