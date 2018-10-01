using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs.Projects
{
    public class TaskDto
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string OwnerId { get; set; }
        public string AssignedTo { get; set; }
        public ProjectDto Project { get; set; }
    }
}
