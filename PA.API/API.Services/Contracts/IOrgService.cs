using API.DataAccess.DTOs.Org;
using System.Threading.Tasks;

namespace API.Services.Contracts
{
    public interface IOrgService
    {
        Task<OrganisationDto> CreateOrganisation(OrganisationDto organisation);
    }
}
