using API.Common;
using API.DataAccess.DTOs.Projects;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.Entities;
using API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IDateTimeHelper _dateTimeHelper;

        public ProjectService(IProjectRepository projectRepository, IDateTimeHelper dateTimeHelper)
        {
            _projectRepository = projectRepository;
            _dateTimeHelper = dateTimeHelper;
        }

        public async Task<string> CreateProject(ProjectDto projectDto)
        {
            var project = new Projects
            {
                Active = true,
                Budget = projectDto.Budget,
                Comments = projectDto.Comments,
                CreatedBy = Guid.NewGuid(), // TODO
                CreatedOn = _dateTimeHelper.GetCurrentDate(),
                EndDate = projectDto.DueDate,
                OrgId = Guid.NewGuid(), // TODO
                Id = 1, // TODO : Guid 
                ProjectManager = Guid.NewGuid(), // TODO: Project manager
                StartDate = projectDto.StartDate,
                Title = projectDto.Name,
                UniqueId = Guid.NewGuid()
            };
            return await _projectRepository.CreateProject(project);
        }

        public ProjectDto UpdateProjecct(ProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}
