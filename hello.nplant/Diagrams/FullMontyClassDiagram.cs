using System.Diagnostics.CodeAnalysis;
using NPlant;

namespace Hello.NPlant.Diagrams;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedParameter.Global")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "UnusedTypeParameter")]
public class FullMontyClassDiagram : ClassDiagram
{
    public FullMontyClassDiagram()
    {
        GenerationOptions.ShowMethods();

        AddClass<Foo>();
    }

    public record Foo(string SomeString, Bar TheBar, Baz<Arg1, Arg2> TheBaz, Baz2<Arg1, Arg2> TheBaz2)
    {
        public void DoSomethingOnFoo()
        {
        }

        public void DoSomethingOnFoo(string parm1)
        {
        }

        public void DoSomethingOnFoo(string parm1, DateTime? parm2, Bar parm3)
        {
        }
    }

    public record Bar(DateTime? SomeDate)
    {
        public void DoSomethingOnBar()
        {
        }

        public void DoSomethingOnBar(string parm1)
        {
        }

        public void DoSomethingOnBar(string parm1, DateTime? parm2, Baz<Arg1, Arg2> parm3)
        {
        }
    }

    public record Baz<T1, T2>(Foo TheFoo, T1 Arg1, T2 Arg2);

    public record Baz2<T1, T2>(string Whatever);

    public class Arg1
    {
    }

    public class Arg2
    {
    }
}