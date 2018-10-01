using API.DataObjects.DTOs;
using API.DataObjects.Entities;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IAuthRepository
    {
        Users ValidateUser(LoginDto loginDto);        
    }
}
