using NPlant.Generation;

namespace Hello.NPlant
{
    class Program
    {
        public static void Main()
        {
            var options = new NPlantRunnerOptions();
            var runner = new NPlantRunner(options, () => new TraceRecorder());
            runner.Run();
        }
    }
}