using API.DataAccess.Repositories.Contracts;
using API.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories
{
    public class ProjectRepository : GenericRepository<Projects>, IProjectRepository
    {
        private readonly DataContext.IPA24Context _database;
        public ProjectRepository(DataContext.IPA24Context database) : base (database)
        {
            _database = database;
        }

        public async Task<string> CreateProject(Projects project)
        {
            await AddAsync(project);
            return "1";
        }

        public async Task<Projects> UpdateProject(Projects project)
        {
            Update(project);
            await _database.SaveChangesAsync();
            return project;
        }        
    }
}
