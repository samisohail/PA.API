using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string BusinessName { get; set; }
        public Guid OrgId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Uan { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? BlockedOn { get; set; }
        public string Reason { get; set; }
        public string Comments { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool Active { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
