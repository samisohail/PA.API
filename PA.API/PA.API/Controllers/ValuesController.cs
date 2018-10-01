using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace PA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        
        public ValuesController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(null);

            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "MyUser")
            };

            var claimsIdentity = new System.Security.Claims.ClaimsIdentity(claims);

            var token = _authService.GenerateToken(claimsIdentity, out bool isAllowed);
            var data = await _userService.AllUsers();
            return Ok(data);
            // new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
