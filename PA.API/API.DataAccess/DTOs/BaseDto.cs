using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DTOs
{
    public abstract class BaseDto
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool Active { get; set; }
    }
}
