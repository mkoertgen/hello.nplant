using NPlant;

namespace Hello.NPlant.Diagrams;

// ReSharper disable once UnusedType.Global
public class SimpleNotesDiagram : ClassDiagram
{
    public SimpleNotesDiagram()
    {
        AddClass<Foo>();
        AddClass<Bar>();
        AddNote("this is a note");
        AddNote("this is another note")
            .AddLine("with another line");
        AddNote("this is connected note")
            .AddLine("with another line")
            .ConnectedToClass<Foo>()
            .ConnectedToClass<Bar>();
    }

    public class Foo
    {
    }

    public class Bar
    {
    }
}