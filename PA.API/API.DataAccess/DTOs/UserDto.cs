using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs
{
    public class UserDto
    {
        public string UniqueId { get; set; }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
