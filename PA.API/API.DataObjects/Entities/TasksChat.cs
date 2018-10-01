using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class TasksChat
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Guid MessageFrom { get; set; }
        public Guid? MessageTo { get; set; }
        public long? ProjectId { get; set; }
        public long? TaskId { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadOn { get; set; }
        public long? ParentMessageId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string LastActivityType { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }

        public ProjectTasks Task { get; set; }
    }
}
