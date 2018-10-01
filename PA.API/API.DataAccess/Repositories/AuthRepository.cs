using API.DataAccess.DataContext;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.DTOs;
using API.DataObjects.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories
{
    public class AuthRepository : GenericRepository<Users> , IAuthRepository
    {
        private readonly IPA24Context _database;
        public AuthRepository(IPA24Context database) : base(database)
        {
            _database = database;
        }

        public Users ValidateUser(LoginDto loginDto)
        {
            try
            {
                var user =  _database.Users.Include(x => x.UserRoles).FirstOrDefault(x => x.Email == loginDto.Username);
                return user;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
