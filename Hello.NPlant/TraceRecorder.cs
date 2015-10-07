using System.Diagnostics;
using NPlant.Generation;

namespace Hello.NPlant
{
    class TraceRecorder : IRunnerRecorder
    {
        public void Dispose() { }
        public void Record(string filePath) { }

        public void Log(string message)
        {
            Trace.TraceInformation(message);
        }
    }
}