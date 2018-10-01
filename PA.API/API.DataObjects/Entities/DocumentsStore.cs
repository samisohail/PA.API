using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class DocumentsStore
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public byte[] Document { get; set; }
        public long DocumentId { get; set; }
        public bool? Active { get; set; }

        public DocumentsDetails DocumentNavigation { get; set; }
    }
}
