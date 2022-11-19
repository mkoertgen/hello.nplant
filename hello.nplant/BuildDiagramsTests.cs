using FluentAssertions;
using NPlant.Generation;
using NPlant.Samples.Titles;
using Xunit;

namespace Hello.NPlant;

public class BuildDiagramsTests
{
    [Fact]
    public void ShouldCreateSampleDiagrams()
    {
        // shows how to generate diagrams from test code
        var options = new NPlantRunnerOptions();
        var runner = new NPlantRunner(options, () => new TraceRecorder());
        runner.Run();

        var docsDir = MkDocs.Load().DocsPath;
        var expected = $"{nameof(SimpleTitledClassDiagram)}.png";
        Find.File(expected).Beneath(docsDir).Should().NotBeNullOrEmpty();
    }
}