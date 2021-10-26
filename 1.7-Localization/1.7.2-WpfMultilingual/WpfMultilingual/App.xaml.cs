using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using WpfMultilingual.Localization;

namespace WpfMultilingual
{
    public partial class App : Application
    {
        // This ITranslationManager would normally be provided by the IoC container:
        public static ITranslationManager TranslationManager { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var supportedLanguages = new[]
            {
                new CultureInfo("de-CH"),
                new CultureInfo("de"),
                new CultureInfo("en"),
                new CultureInfo("fr")
            };
            var translationProvider = new ResxTranslationProvider(WpfMultilingual.Properties.Resources.ResourceManager);
            var translationManager = new TranslationManager(translationProvider, supportedLanguages);
            translationManager.CurrentLanguage = supportedLanguages[1];

            TranslationData.Initialize(translationManager);
            TranslationManager = translationManager;

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
    }
}