using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs
{
    public sealed class TokenDto
    {
        public string Id { get; set; }
        public string Organisation { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
