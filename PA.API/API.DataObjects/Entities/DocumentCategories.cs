using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class DocumentCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool? Active { get; set; }
    }
}
