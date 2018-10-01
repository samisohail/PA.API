using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataObjects.DTOs.User
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid OrgId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public string[] Roles { get; set; }
    }
}
