using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class ParentTasks
    {
        public long Id { get; set; }
        public long TaskId { get; set; }
        public bool? Active { get; set; }

        public ProjectTasks Task { get; set; }
    }
}
