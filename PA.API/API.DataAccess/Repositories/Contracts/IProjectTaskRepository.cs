using API.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IProjectTaskRepository
    {
        void CreateTask(ProjectTasks task);
        void UpdateTask(ProjectTasks task);
    }
}
