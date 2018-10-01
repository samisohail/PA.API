using API.DataAccess.DTOs;
using API.DataObjects.DTOs.User;
using API.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<Users> CreateUser(CreateUserDto createUserDto, Guid userId);
        Task<bool> DoesUserExist(string email);
        Task<IEnumerable<UserDto>> Users();        
        Task<IEnumerable<UserDto>> GetAll();
        Task<Users> GetUser(string userId);
    }
}
