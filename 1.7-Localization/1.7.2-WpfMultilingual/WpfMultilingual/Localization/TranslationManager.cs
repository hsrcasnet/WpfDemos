using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace WpfMultilingual.Localization
{
    public class TranslationManager : ITranslationManager
    {
        private readonly ITranslationProvider translationProvider;
        private readonly CultureInfo[] supportedLanguages;

        public TranslationManager(ITranslationProvider translationProvider, CultureInfo[] supportedLanguages)
        {
            this.translationProvider = translationProvider;
            this.supportedLanguages = supportedLanguages;
        }

        public CultureInfo CurrentLanguage
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value != Thread.CurrentThread.CurrentUICulture)
                {
                    Thread.CurrentThread.CurrentCulture = value;
                    Thread.CurrentThread.CurrentUICulture = value;

                    CultureInfo.DefaultThreadCurrentCulture = value;
                    CultureInfo.DefaultThreadCurrentUICulture = value;

                    this.OnLanguageChanged();
                }
            }
        }

        public IEnumerable<CultureInfo> Languages => this.supportedLanguages;

        public event EventHandler LanguageChanged;

        private void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        public string Translate(string key)
        {
            var translatedValue = this.translationProvider.Translate(key);
            if (translatedValue != null)
            {
                return translatedValue;
            }

            throw new ArgumentException($"Key '{key}' was not found for culture '{this.CurrentLanguage.Name}'.");
        }
    }
}
