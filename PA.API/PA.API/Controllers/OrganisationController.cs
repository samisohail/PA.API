using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess.DTOs.Org;
using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA.API.ViewModels;
using PA.API.ViewModels.Org;

namespace PA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrgService _orgService;
        public OrganisationController(IOrgService orgService)
        {
            _orgService = orgService;
        }

        [HttpPost("add")]        
        [ProducesResponseType(typeof(ApiResult<OrganisationVM>), 200)]
        public async Task<IActionResult> CreateOrganisation([FromBody] OrganisationVM organisation)
        {
            var organisationDto = new OrganisationDto
            {
                Active = true,
                Address = organisation.Address,
                Comments = organisation.Comments,
                Description = organisation.Description,
                Email = organisation.Email,
                Name = organisation.Name,
                Phone = organisation.Phone                
            };
            await _orgService.CreateOrganisation(organisationDto);
            return Ok(new { status = true, data = string.Empty , message = "organisation account created." });
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "value";
        }

    }
}