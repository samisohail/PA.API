using API.DataAccess.DTOs;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.DTOs.User;
using API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            var user = await _userRepository.CreateUser(createUserDto, Guid.NewGuid());
            return user != null ? true : false;
        }

        public async Task<IEnumerable<UserDto>> AllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserDto> GetUser(string userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user != null)
            {
                return new UserDto
                {
                    Id = 1,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UniqueId = user.Id.ToString(),
                    Email = user.Email
                };                
            }
            return null;
        }

        public async Task<bool> DoesUserExists(string email)
        {
            var result = await _userRepository.DoesUserExist(email);
            return result;
        }
    }
}

