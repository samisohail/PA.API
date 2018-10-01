using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class ProjectTasks
    {
        public ProjectTasks()
        {
            ParentTasks = new HashSet<ParentTasks>();
            TasksChat = new HashSet<TasksChat>();
        }

        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public long ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long TaskOwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? AssignedToUserId { get; set; }
        public int StatusId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool NeedApproval { get; set; }
        public long? ApproverId { get; set; }
        public int? AppovalStatusId { get; set; }
        public DateTime? AppovalStatusDate { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal ActualHours { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string LastActivityType { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }
        public int? AlertTypeId { get; set; }

        public ICollection<ParentTasks> ParentTasks { get; set; }
        public ICollection<TasksChat> TasksChat { get; set; }
    }
}
