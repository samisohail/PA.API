using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class ProjectTeamMembers
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string LastActivityType { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }
        public bool MemberAcceptedReq { get; set; }
        public DateTime? MemberResponseDate { get; set; }
        public string MemberResponseComments { get; set; }
        public string RoleInProject { get; set; }
    }
}
