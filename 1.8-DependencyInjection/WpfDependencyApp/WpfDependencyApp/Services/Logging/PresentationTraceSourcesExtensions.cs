using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WpfDependencyApp.Services.Logging
{
    public static class PresentationTraceSourcesExtensions
    {
        public static IServiceProvider UsePresentationTraceSourcesLogging(this IServiceProvider serviceProvider, Action<PresentationTraceSourcesLoggingOptions> options = null)
        {
            var defaultOptions = new PresentationTraceSourcesLoggingOptions();
            options?.Invoke(defaultOptions);

            PresentationTraceSources.Refresh();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            foreach (var traceSourceConfig in defaultOptions.TraceSources.Where(t => t.IsEnabled))
            {
                var listener = traceSourceConfig.TraceSource.Listeners[traceSourceConfig.LoggerName];
                if (listener == null)
                {
                    var logger = loggerFactory.CreateLogger(traceSourceConfig.LoggerName);
                    var loggerTraceListener = new LoggerTraceListener(traceSourceConfig.LoggerName, logger, traceSourceConfig.LogLevel);
                    traceSourceConfig.TraceSource.Listeners.Clear();
                    traceSourceConfig.TraceSource.Listeners.Add(loggerTraceListener);
                    traceSourceConfig.TraceSource.Listeners.Add(new DebuggerBreakTraceListener());

                    var currentSourceLevels = traceSourceConfig.TraceSource.Switch.Level;
                    if (defaultOptions.SourceLevels is SourceLevels sourceLevelsValue &&
                        sourceLevelsValue != SourceLevels.Off &&
                        currentSourceLevels == SourceLevels.Off)
                    {
                        traceSourceConfig.TraceSource.Switch.Level = sourceLevelsValue;
                    }
                }
            }

            return serviceProvider;
        }
    }
}
