using API.DataAccess.DTOs;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.DTOs.User;
using API.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<Users>,  IUserRepository
    {
        private readonly DataContext.IPA24Context _database;

        public UserRepository(DataContext.IPA24Context database) : base (database)
        {
            _database = database;
        }

        public async Task<Users> CreateUser(CreateUserDto userDto, Guid userId)
        {
            Users user = new Users
            {
                AccessFailedCount = 0,
                Address = userDto.Address,                
                BusinessName = string.Empty,
                Comments = userDto.Comments,
                CityId = 1,
                CountryId = 1,
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
                Dob = DateTime.Now,
                Email = userDto.Email,
                EmailConfirmed = false,
                FirstName = userDto.FirstName,
                Gender = "m",
                Id = Guid.NewGuid(),
                Active = true,
                LastName = userDto.LastName,
                OrgId = userDto.OrgId,                
                Phone = userDto.Phone,
                PhoneNumberConfirmed = false,                
                TwoFactorEnabled = false,
                PasswordSalt = string.Empty,
                Password = "123456"                
            };
            await AddAsync(user);
            return user;
        }

        public Task<IEnumerable<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesUserExist(string email)
        {
            return _database.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await FindByConditionAync(x => x.Active);
            return users.Select(x => new UserDto
            {
                Id = 1,
                FirstName = x.FirstName,
                LastName = x.LastName                
            });            
        }

        public async Task<Users> GetUser(string userId)
        {
            var user = await _database.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Id == Guid.NewGuid());
            return user;
        }

        public async Task<IEnumerable<UserDto>> Users()
        {
            var data = await _database.Users.Select(x => new UserDto
            {
                Id = 1,
                FirstName = x.FirstName,
                LastName = x.LastName
                // UniqueId = x.Id
            }).ToListAsync();

            return data;
        }
    }
}
