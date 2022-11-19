using System.Diagnostics.CodeAnalysis;
using NPlant;

namespace Hello.NPlant.Diagrams;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public class SimpleEnumDiagram : ClassDiagram
{
    public SimpleEnumDiagram()
    {
        AddClass<Foo>();
        AddEnum<RandomEnum>();
    }

    public record Foo(string SomeString, Bar TheBar, Baz TheBaz);

    public record Bar(DateTime? SomeDate, BarTypes Type);

    public record Baz(Foo TheFoo);

    public enum RandomEnum
    {
        Member1 = 0,
        Member2 = 1,
        Member3 = 2
    }

    public enum BarTypes
    {
        HighBar = 0,
        LowBar = 1
    }
}