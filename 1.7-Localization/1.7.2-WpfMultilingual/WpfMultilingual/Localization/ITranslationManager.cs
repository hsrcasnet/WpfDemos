using System;
using System.Collections.Generic;
using System.Globalization;

namespace WpfMultilingual.Localization
{
    public interface ITranslationManager
    {
        event EventHandler LanguageChanged;

        IEnumerable<CultureInfo> Languages { get; }

        CultureInfo CurrentLanguage { get; set; }

        string Translate(string key);
    }
}