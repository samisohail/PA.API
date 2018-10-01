using System;
using System.Collections.Generic;

namespace API.DataObjects.Entities
{
    public partial class ConfigurationTypes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
