using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA.API.ViewModels.User
{
    public class CreateUserVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrgId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public string[] Roles { get; set; }
    }
}
