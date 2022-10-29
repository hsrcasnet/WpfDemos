using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using WpfMultilingual.Localization;
using WpfMultilingual.Properties;

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

        // Demo: Strings with variables have to be composed in the viewmodel.
        //public string MyProperty
        //{
        //    get
        //    {
        //        if (this.translationManager == null)
        //        {
        //            return null;
        //        }

        //        return string.Format(this.translationManager.Translate(nameof(Resources.CurrentTimeLabelText)), DateTime.Now.ToString("t"));
        //    }
        //}
    }
}