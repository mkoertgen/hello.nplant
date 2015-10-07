using NPlant;

namespace Hello.NPlant.Diagrams
{
    public class SimpleTitledClassDiagram : ClassDiagram
    {
        public SimpleTitledClassDiagram()
        {
            Titled("This is a big fat title using <i><b>html!</b></i>");
        }

        public class Foo
        {
            public string SomeField;
        }
    }
}