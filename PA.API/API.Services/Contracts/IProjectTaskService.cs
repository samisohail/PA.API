using API.DataAccess.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Services.Contracts
{
    public interface IProjectTaskService
    {
        string CreateProjectTask(TaskDto task);
        TaskDto UpdateProjectTask(TaskDto task);
        bool DeleteProjectTask(TaskDto task);
    }
}
