using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataObjects.DTOs.User;
using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA.API.ViewModels.User;

namespace PA.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(201, Type = typeof(bool))]
        public async Task<IActionResult> CreateUser(CreateUserVM user)
        {
            var userDto = new CreateUserDto{
                Address = user.Address,
                Comments = user.Comments,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                // OrgId = user.OrgId,
                Password = user.Password,
                Phone = user.Phone,
                Roles = user.Roles
            };
            await _userService.CreateUser(userDto);
            return Ok(true);
        }
    }
}