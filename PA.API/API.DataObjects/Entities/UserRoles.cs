using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class UserRoles
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public bool? Active { get; set; }

        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
