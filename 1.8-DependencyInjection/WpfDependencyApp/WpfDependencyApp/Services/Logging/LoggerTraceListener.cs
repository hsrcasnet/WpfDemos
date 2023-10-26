using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WpfDependencyApp.Services.Logging
{
    public class LoggerTraceListener : TraceListener
    {
        private readonly ILogger logger;
        private readonly LogLevel logLevel;

        public LoggerTraceListener(string name, ILogger logger, LogLevel logLevel)
            : base(name)
        {
            this.logger = logger;
            this.logLevel = logLevel;
        }

        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
            this.logger.Log(this.logLevel, message);
        }
    }
}