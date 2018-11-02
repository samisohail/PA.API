using API.Common;
using API.DataAccess.DTOs.Org;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.Entities;
using API.Services.Contracts;
using System.Threading.Tasks;

namespace API.Services.Implementations
{
    public class OrgService : IOrgService
    {
        private readonly IOrganisationRepository _organisationResposiory;

        public OrgService(IOrganisationRepository organisationRepository)
        {
            _organisationResposiory = organisationRepository;
        }
        public async Task<OrganisationDto> CreateOrganisation(OrganisationDto organisationDto, string userId)
        {
            var organisation = new Organisations
            {
                Active = true,
                Address = organisationDto.Address,
                Comments = organisationDto.Comments,
                ContactEmail = organisationDto.Email,
                ContactPhone = organisationDto.Phone,
                CreatedBy = ,
                CreatedOn = DateTimeHelper.Instance.GetCurrentDate(),
                Description = organisationDto.Description,
                LastActivityType = "I",
                Name = organisationDto.Name
            };
            _organisationResposiory.CreateOrganisation(organisation);
            await _organisationResposiory.SaveAsync();
            return organisationDto;
        }
    }
}
