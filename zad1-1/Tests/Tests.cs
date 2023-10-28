using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain;
using Infra;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var DocumentsRepository = new DocumentsRepository();

            var DocumentsService = new DocumentsService();
            
            var document = new Document()
            {
                Statuses = new List<DocumentStatus>()
                {
                    new DocumentStatus()
                    {
                        Status = DocumentStatusEnum.Draft,
                    }
                }
            };
            
            DocumentsRepository.CreateDocument(document);
            
            document.Statuses = new List<DocumentStatus>()
            {
                new DocumentStatus()
                {
                    Status = DocumentStatusEnum.Draft,
                },
                new DocumentStatus()
                {
                    Status = DocumentStatusEnum.Published,
                }
            };
            
            DocumentsService.UpdateDocumentStatus(1, DocumentStatusEnum.Published);
            DocumentsService.UpdateDocumentStatus(2, DocumentStatusEnum.Cancelled);
            
            Assert.True(DocumentsRepository.GetById(1).Statuses.Any(x => x.Status == DocumentStatusEnum.Published));
            Assert.True(DocumentsRepository.GetById(2).Statuses.Any(x => x.Status == DocumentStatusEnum.Cancelled));
            
        }
    }
}