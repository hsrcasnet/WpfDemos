using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfMultilingual.Localization;

namespace WpfMultilingual
{
    public partial class App : Application
    {
        // This ITranslationManager would normally be provided by the IoC container:
        public static ITranslationManager TranslationManager { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Demo: Define set of supported cultures only vs. allow all cultures to be selected
            var supportedLanguages = new[]
            {
                new CultureInfo("de-CH"),
                new CultureInfo("de"),
                new CultureInfo("en"),
                new CultureInfo("fr")
            };
            //var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var translationProvider = new ResxTranslationProvider(WpfMultilingual.Properties.Resources.ResourceManager);
            var translationManager = new TranslationManager(translationProvider, supportedLanguages);

            // Demo: What happens if the CurrentLanguage is not set?
            //translationManager.CurrentLanguage = supportedLanguages[1];

            // Demo: What happens with task's cultures if DefaultThreadCurrentCulture is not set?
            RunTasksInBackground();

            TranslationData.Initialize(translationManager);
            TranslationManager = translationManager;

            //FrameworkElement.LanguageProperty.OverrideMetadata(
            //    typeof(FrameworkElement),
            //    new FrameworkPropertyMetadata(
            //        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }

        /// <summary>
        ///     When a thread is started, its culture is initially determined as follows:
        ///     - By retrieving the culture that is specified by the CultureInfo.DefaultThreadCurrentCulture property in the
        ///     application domain in which the thread is executing
        ///     - If CultureInfo.DefaultThreadCurrentCulture is null, the system default culture is used
        /// </summary>
        private static void RunTasksInBackground()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Console.WriteLine("The current culture is {0}", currentCulture.Name);
            Console.WriteLine("Application thread is thread {0}", Thread.CurrentThread.ManagedThreadId);

            // Launch some tasks and display their current culture...
            var tasks = new List<Task>();
            for (var index = 0; index < 100; index++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Console.WriteLine($"Task {Task.CurrentId} on thread {Thread.CurrentThread.ManagedThreadId} has " +
                                      $"CurrentCulture={Thread.CurrentThread.CurrentCulture.Name}, " +
                                      $"CurrentUICulture={Thread.CurrentThread.CurrentUICulture.Name}");
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}