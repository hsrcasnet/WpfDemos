using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WpfDependencyApp.Services.Logging
{
    [DebuggerDisplay("TraceSource: {this.TraceSource.Name}, Logger: {this.LoggerName}")]
    public sealed class TraceSourceConfig
    {
        public TraceSourceConfig(TraceSource traceSource, string loggerName)
        {
            this.TraceSource = traceSource;
            this.LoggerName = loggerName;
        }

        public TraceSource TraceSource { get; }

        /// <summary>
        /// Logger name used for the target <see cref="ILogger"/> instance.
        /// </summary>
        public string LoggerName { get; set; }

        /// <summary>
        /// Target log level used when logging messages from PresentationTraceSources
        /// to <see cref="ILogger"/> of Microsoft.Extensions.Logging.
        /// Default: LogLevel.Error
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Error;

        /// <summary>
        /// Enables or disables the current trace source.
        /// </summary>
        public bool IsEnabled { get; set; } = true;
    }
}
