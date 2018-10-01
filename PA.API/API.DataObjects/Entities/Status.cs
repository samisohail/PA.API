using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string Comments { get; set; }
        public string LastActivityType { get; set; }
        public bool? Active { get; set; }
    }
}
