using System.Collections.Generic;

namespace Domain
{
    public class Document
    {
        public int Id { get; set; }
        public IEnumerable<DocumentStatus> Statuses { get; set; }
    }

    public class DocumentStatus
    {
        public DocumentStatusEnum Status { get; set; }
    }
    
    public enum DocumentStatusEnum
    {
        Draft = 1,
        Published = 2,
        Cancelled = 3,
        Archived = 4
    }
}