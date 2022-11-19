using System.Diagnostics;
using Hello.NPlant;
using NPlant.Generation;

Trace.Listeners.Add(new ConsoleTraceListener());

var options = new NPlantRunnerOptions();
var runner = new NPlantRunner(options, () => new TraceRecorder());
runner.Run();
