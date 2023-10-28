using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Infra
{
    public class DocumentsRepository
    {
        private List<Document> _documents = new List<Document>();
        public void CreateDocument(Document document)
        {
            document.Id = _documents.Max(x => x.Id);
            _documents.Add(document);
        }
        
        public Document GetById(int id)
        {
            return _documents.FirstOrDefault(x => x.Id == id) ?? null;
        }
    }
}