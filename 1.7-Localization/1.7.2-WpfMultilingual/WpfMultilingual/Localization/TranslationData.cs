using System;
using System.ComponentModel;
using System.Windows;

namespace WpfMultilingual.Localization
{
    public class TranslationData : IWeakEventListener, INotifyPropertyChanged, IDisposable
    {
        private static ITranslationManager translationManager;
        private readonly string key;

        public static void Initialize(TranslationManager translationManager)
        {
            TranslationData.translationManager = translationManager;
        }

        public TranslationData(string key)
        {
            this.key = key;

            if (translationManager != null)
            {
                LanguageChangedEventManager.AddListener(translationManager, this);
            }
        }

        public object Value => translationManager?.Translate(this.key);

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LanguageChangedEventManager))
            {
                this.OnLanguageChanged();
                return true;
            }

            return false;
        }

        private void OnLanguageChanged()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Value)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ~TranslationData()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (translationManager != null)
                {
                    LanguageChangedEventManager.RemoveListener(translationManager, this);
                }
            }
        }
    }
}