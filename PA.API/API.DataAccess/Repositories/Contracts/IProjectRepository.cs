using API.DataObjects.Entities;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IProjectRepository
    {
        Task<string> CreateProject(Projects project);
        Task<Projects> UpdateProject(Projects project);
    }
}
