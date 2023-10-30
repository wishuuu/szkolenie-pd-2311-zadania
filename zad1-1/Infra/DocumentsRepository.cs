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
            document.Id = _documents.Count > 0 ? _documents.Max(x => x.Id) : 1;
            _documents.Add(document);
        }
        
        public Document GetById(int id)
        {
            return _documents.FirstOrDefault(x => x.Id == id) ?? null;
        }
    }
}