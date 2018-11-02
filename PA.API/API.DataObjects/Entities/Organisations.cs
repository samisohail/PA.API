using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class Organisations
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public string LastActivityType { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }
    }
}
