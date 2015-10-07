using System;
using NPlant;

namespace Hello.NPlant
{
    class MyDiagram : ClassDiagram
    {
        public MyDiagram()
        {
            AddAllSubClassesOff<IRepository<Document>>()
                .AddNote("The document is the main entity")
                .ConnectedToClass<Document>();

        }
    }

    interface IRepository<T>
    {
        T Open(Guid id);
        void Save(T record);
    }

    class DocumentRepository : IRepository<Document>
    {
        public Document Open(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Document record)
        {
            throw new NotImplementedException();
        }
    }

    class Document
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
