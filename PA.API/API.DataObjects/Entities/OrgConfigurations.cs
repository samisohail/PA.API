using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class OrgConfigurations
    {
        public long Id { get; set; }
        public long ConfigurationId { get; set; }
        public long OrganizationId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifyReason { get; set; }
        public string Comments { get; set; }
        public string LastActivityType { get; set; }
        public bool? Active { get; set; }
    }
}
