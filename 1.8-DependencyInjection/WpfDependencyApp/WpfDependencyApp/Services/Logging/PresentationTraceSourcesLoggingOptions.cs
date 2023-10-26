using System.Diagnostics;

namespace WpfDependencyApp.Services.Logging
{
    public sealed class PresentationTraceSourcesLoggingOptions
    {
        /// <summary>
        /// Specifies the levels of trace messages filtered by all PresentationTraceSources.
        /// Default: SourceLevels.Warning | SourceLevels.Error
        /// </summary>
        public SourceLevels? SourceLevels { get; set; } = System.Diagnostics.SourceLevels.Warning | System.Diagnostics.SourceLevels.Error;

        /// <summary>
        /// Configurations for the trace sources.
        /// </summary>
        public TraceSourceConfigs TraceSources { get; set; } = new TraceSourceConfigs();
    }
}