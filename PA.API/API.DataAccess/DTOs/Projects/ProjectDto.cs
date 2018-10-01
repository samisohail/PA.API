using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs.Projects
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProjectType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Organization { get; set; }
        public long Budget { get; set; }
        public string Comments { get; set; }
    }
}
