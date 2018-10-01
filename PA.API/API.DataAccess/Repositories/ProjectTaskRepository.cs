using API.DataAccess.Repositories.Contracts;
using API.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.Repositories
{
    public class ProjectTaskRepository : GenericRepository<ProjectTasks>, IProjectTaskRepository
    {
        private readonly API.DataAccess.DataContext.IPA24Context _database;

        public ProjectTaskRepository(DataContext.IPA24Context database) : base (database)
        {
            _database = database;
        }

        public void CreateTask(ProjectTasks task)
        {
            Add(task);
        }

        public void UpdateTask(ProjectTasks task)
        {
            Update(task);
        }
    }
}
