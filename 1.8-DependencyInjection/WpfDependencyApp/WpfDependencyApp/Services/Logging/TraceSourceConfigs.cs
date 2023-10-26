using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WpfDependencyApp.Services.Logging
{
    public sealed class TraceSourceConfigs : IEnumerable<TraceSourceConfig>
    {
        public TraceSourceConfigs()
        {
            this.AnimationSource = new TraceSourceConfig(PresentationTraceSources.AnimationSource, "AnimationSourceLogger");
            this.DataBindingSource = new TraceSourceConfig(PresentationTraceSources.DataBindingSource, "DataBindingSourceLogger");
            this.DependencyPropertySource = new TraceSourceConfig(PresentationTraceSources.DependencyPropertySource, "DependencyPropertySourceLogger");
            this.DocumentsSource = new TraceSourceConfig(PresentationTraceSources.DocumentsSource, "DocumentsSourceLogger");
            this.FreezableSource = new TraceSourceConfig(PresentationTraceSources.FreezableSource, "FreezableSourceLogger");
            this.HwndHostSource = new TraceSourceConfig(PresentationTraceSources.HwndHostSource, "HwndHostSourceLogger");
            this.MarkupSource = new TraceSourceConfig(PresentationTraceSources.MarkupSource, "MarkupSourceLogger");
            this.NameScopeSource = new TraceSourceConfig(PresentationTraceSources.NameScopeSource, "NameScopeSourceLogger");
            this.ResourceDictionarySource = new TraceSourceConfig(PresentationTraceSources.ResourceDictionarySource, "ResourceDictionarySourceLogger");
            this.RoutedEventSource = new TraceSourceConfig(PresentationTraceSources.RoutedEventSource, "RoutedEventSourceLogger");
            this.ShellSource = new TraceSourceConfig(PresentationTraceSources.ShellSource, "ShellSourceLogger");
        }

        public TraceSourceConfig AnimationSource { get; }

        public TraceSourceConfig DataBindingSource { get; }

        public TraceSourceConfig DependencyPropertySource { get; }

        public TraceSourceConfig DocumentsSource { get; }

        public TraceSourceConfig FreezableSource { get; }

        public TraceSourceConfig HwndHostSource { get; }

        public TraceSourceConfig MarkupSource { get; }

        public TraceSourceConfig NameScopeSource { get; }

        public TraceSourceConfig ResourceDictionarySource { get; }

        public TraceSourceConfig RoutedEventSource { get; }

        public TraceSourceConfig ShellSource { get; }

        public IEnumerator<TraceSourceConfig> GetEnumerator()
        {
            yield return this.AnimationSource;
            yield return this.DataBindingSource;
            yield return this.DependencyPropertySource;
            yield return this.DocumentsSource;
            yield return this.FreezableSource;
            yield return this.HwndHostSource;
            yield return this.MarkupSource;
            yield return this.NameScopeSource;
            yield return this.ResourceDictionarySource;
            yield return this.RoutedEventSource;
            yield return this.ShellSource;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}