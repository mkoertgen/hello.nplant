using FluentAssertions;
using Xunit;

namespace Hello.NPlant;

public class MkDocsTests
{
    [Fact]
    public void ShouldLoad()
    {
        var mkdocs = MkDocs.Load();
        mkdocs.FileLocation.Should().NotBeNullOrWhiteSpace();
        File.Exists(mkdocs.FileLocation).Should().BeTrue();
        Directory.Exists(mkdocs.DocsPath).Should().BeTrue();
    }
}