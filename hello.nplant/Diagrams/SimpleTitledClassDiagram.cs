using System.Diagnostics.CodeAnalysis;
using NPlant;

namespace Hello.NPlant.Diagrams;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class SimpleTitledClassDiagram : ClassDiagram
{
    public SimpleTitledClassDiagram()
    {
        Titled("This is a big fat title using <i><b>html!</b></i>");
    }

    public record Foo(string SomeField);
}