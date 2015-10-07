using NPlant.Generation;
using NUnit.Framework;

namespace Hello.NPlant
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    class BuildDiagramsFixture
    {
        [Test]
        public void Create_SampleDiagrams()
        {
            var options = new NPlantRunnerOptions();
            var runner = new NPlantRunner(options, () => new TraceRecorder());
            runner.Run();
        }
    }
}