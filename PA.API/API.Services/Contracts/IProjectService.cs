using API.DataAccess.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Contracts
{
    public interface IProjectService
    {
        Task<string> CreateProject(ProjectDto project);
        ProjectDto UpdateProjecct(ProjectDto project);        
    }
}
