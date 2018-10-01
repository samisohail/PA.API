using API.DataAccess.DTOs;
using API.DataObjects.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.Contracts
{
    public interface IAuthService
    {
        string ValidateUser(LoginDto loginDto);
        string GenerateToken(ClaimsIdentity claimsIdentity, out bool isAllowed);        
    }
}
