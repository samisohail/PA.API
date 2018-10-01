using API.DataAccess.DTOs.Projects;
using API.DataAccess.Repositories.Contracts;
using API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Services.Implementations
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public string CreateProjectTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProjectTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public TaskDto UpdateProjectTask(TaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}
