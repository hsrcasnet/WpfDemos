using System.Diagnostics;

namespace WpfDependencyApp.Services.Logging
{
    public class DebuggerBreakTraceListener : TraceListener
    {
        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
            //if (Debugger.IsAttached)
            //{
            //    Debugger.Break();
            //}
        }
    }
}