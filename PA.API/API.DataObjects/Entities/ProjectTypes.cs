using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class ProjectTypes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? OrgId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string LastActivityType { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }
    }
}
