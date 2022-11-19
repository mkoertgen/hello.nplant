using System.Diagnostics;
using NPlant.Generation;

namespace Hello.NPlant;

internal sealed class TraceRecorder : IRunnerRecorder
{
    public void Dispose()
    {
        // nothing to do (Sonar)
    }

    public void Record(string filePath)
    {
        // nothing to do (Sonar)
    }

    public void Log(string message)
    {
        Trace.TraceInformation(message);
    }
}