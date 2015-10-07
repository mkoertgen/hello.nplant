using System.Collections.Generic;
using NPlant;

namespace Hello.NPlant
{
    public class SimpleDiagramFactory : IDiagramFactory
    {
        public IEnumerable<ClassDiagram> GetDiagrams()
        {
            return new ClassDiagram[]
            {
                new MyDiagram(),
            };
        }
    }
}