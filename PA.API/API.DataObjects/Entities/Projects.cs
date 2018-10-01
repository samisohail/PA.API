using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class Projects
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Title { get; set; }
        public Guid OrgId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ProjectManager { get; set; }
        public decimal Budget { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifyReason { get; set; }
        public string Comments { get; set; }
        public string LastActivityType { get; set; }
        public bool? Active { get; set; }
    }
}
