using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class DocumentsDetails
    {
        public DocumentsDetails()
        {
            DocumentsStore = new HashSet<DocumentsStore>();
        }

        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Title { get; set; }
        public string DocumentName { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteReason { get; set; }
        public string LastActivityType { get; set; }
        public bool? Active { get; set; }
        public int? DocumentCategoryId { get; set; }

        public ICollection<DocumentsStore> DocumentsStore { get; set; }
    }
}
