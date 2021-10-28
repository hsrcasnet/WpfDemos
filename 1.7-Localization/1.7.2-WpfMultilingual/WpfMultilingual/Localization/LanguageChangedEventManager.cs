using System;
using System.Windows;

namespace WpfMultilingual.Localization
{
    internal class LanguageChangedEventManager : WeakEventManager
    {
        internal static void AddListener(ITranslationManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        internal static void RemoveListener(ITranslationManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            this.DeliverEvent(sender, e);
        }

        protected override void StartListening(object source)
        {
            var translationManager = (ITranslationManager)source;
            translationManager.LanguageChanged += this.OnLanguageChanged;
        }

        protected override void StopListening(object source)
        {
            var translationManager = (ITranslationManager)source;
            translationManager.LanguageChanged -= this.OnLanguageChanged;
        }

        private static LanguageChangedEventManager CurrentManager
        {
            get
            {
                var managerType = typeof(LanguageChangedEventManager);
                var languageChangedEventManager = (LanguageChangedEventManager)GetCurrentManager(managerType);
                if (languageChangedEventManager == null)
                {
                    languageChangedEventManager = new LanguageChangedEventManager();
                    SetCurrentManager(managerType, languageChangedEventManager);
                }

                return languageChangedEventManager;
            }
        }
    }
}