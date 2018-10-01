using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string LastActivity { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
