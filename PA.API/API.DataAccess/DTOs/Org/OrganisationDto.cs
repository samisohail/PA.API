using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs.Org
{
    public class OrganisationDto : BaseDto
    {
        public string Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
    }
}
