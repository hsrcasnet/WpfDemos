using System.Resources;
using System.Threading;

namespace WpfMultilingual.Localization
{
    internal class ResxTranslationProvider : ITranslationProvider
    {
        private readonly ResourceManager resourceManager;

        public ResxTranslationProvider(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public string Translate(string key)
        {
            var translatedValue = resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
            return translatedValue;
        }
    }
}