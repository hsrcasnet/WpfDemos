using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfMultilingual.Localization
{
    /// <summary>
    ///     The Translate Markup extension returns a binding to a TranslationData
    ///     that provides a translated resource of the specified key
    /// </summary>
    public class TranslateExtension : MarkupExtension
    {
        public TranslateExtension(string key)
        {
            this.Key = key;
        }

        [ConstructorArgument("key")]
        public string Key { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding(nameof(TranslationData.Value))
            {
                Source = new TranslationData(this.Key)
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}