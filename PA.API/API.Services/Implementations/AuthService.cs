using API.DataAccess.DTOs;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.DTOs;
using API.Services.Contracts;
using API.Services.Contracts.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly SecurityKey _signingKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly string _audience;
        private readonly string _issuingAuthority;

        private readonly IUserService _userService;
        private readonly IAuthRepository _authRepository;
        private readonly IEncryptPBKDF2 _encryptPBKDF2;

        public AuthService(IConfiguration config, IUserService userService
                            , IAuthRepository authRepository
                            , IEncryptPBKDF2 encryptPBKDF2)
        {
            _userService = userService;
            _authRepository = authRepository;
            _encryptPBKDF2 = encryptPBKDF2;

            _signingKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("PakGrwiepoxjedLaDiEpGBVxxkpqWYzztbl"));
            _signingCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha512);

            _issuingAuthority = config.GetSection("jwt")["pa247authority"];
            _audience = config.GetSection("jwt")["audience"];
        }
        
        public string GenerateToken(ClaimsIdentity claimsIdentity, out bool isAllowed)
        {
            isAllowed = true;

            Claim userIdClaim = claimsIdentity.FindFirst("Name");
            //if (userIdClaim == null)
            //{
            //    return String.Empty;
            //}
            //if (!int.TryParse(userIdClaim.Value, out var userId))
            //{
            //    throw new UnauthorizedAccessException();
            //}

            // var user = _userService.GetUser(userId);

            // var token = new DataAccess.DTOs.TokenDto();

            var claims = new List<Claim>()
            {
                new Claim("Email", "Email"),
                new Claim("Id", "Id"),
                new Claim("Organisation", "Organisation"),
                new Claim("Roles", "Roles")
            };
            
            var tokenDescription = new JwtSecurityToken(
            issuer: _issuingAuthority,
            audience: _audience,
            claims: claimsIdentity.Claims,
            expires: DateTime.Now.AddMinutes(30),            
            signingCredentials: _signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        }

        public string ValidateUser(LoginDto loginDto)
        {
            bool isAllowed = false;

            var user = _authRepository.ValidateUser(loginDto);
            if (user == null)
            {
                return null;
            }

            // var salt = user.Password;
            // var password = Encoding.ASCII.GetBytes(user.PasswordSalt);

            //var decryptedPassword = _encryptPBKDF2.Decrypt(password, salt);
            //if (!decryptedPassword.Equals(loginDto.Password))
            //{
            //    return null;
            //}

            
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FirstName , ClaimValueTypes.String),
                new Claim(ClaimTypes.Surname, user.LastName, ClaimValueTypes.String),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String)
            };
            var userIdentity = new ClaimsIdentity(claims, "Passport");

            return GenerateToken(userIdentity, out isAllowed);
        }
    }
}
