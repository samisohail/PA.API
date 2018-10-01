using API.DataAccess.DTOs;
using API.DataObjects.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto createUserDto);
        Task<bool> DoesUserExists(string email);
        Task<IEnumerable<UserDto>> AllUsers();
        Task<UserDto> GetUser(string userId);
    }
}
