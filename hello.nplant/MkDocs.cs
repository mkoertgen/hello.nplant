using System.Diagnostics.CodeAnalysis;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Hello.NPlant;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal class MkDocs
// records not yet supported in YamlDotNet: https://github.com/aaubry/YamlDotNet/issues/571
{
    public static MkDocs Load(string? fileName = null)
    {
        var file = fileName ?? Find.File("mkdocs.yml").Above(Environment.CurrentDirectory)!;
        // https://github.com/aaubry/YamlDotNet/wiki/Samples.DeserializeObjectGraph
        using TextReader input = File.OpenText(file);
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
        var mkdocs = deserializer.Deserialize<MkDocs>(input);
        mkdocs.FileLocation = file;
        return mkdocs;
    }

    [YamlIgnore]
    public string? FileLocation { get; private set; }
    
    public string? SiteName { get; set; }
    public string? RepoUrl { get; set; }
    public string DocsDir { get; set; } = "docs";
    public string SiteDir { get; set; } = "site";
    public string DocsPath => Path.Combine(Path.GetDirectoryName(FileLocation!)!, DocsDir);
}