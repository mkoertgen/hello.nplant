using NPlant;

namespace Hello.NPlant.Diagrams
{
    public class SimpleLegendDiagram : ClassDiagram
    {
        public SimpleLegendDiagram()
        {
            AddClass<Foo>();
            AddClass<Bar>();
            LegendOf("This is my legend")
                .DisplayLeft();
        }

        public class Foo { }
        public class Bar { }
    }
}