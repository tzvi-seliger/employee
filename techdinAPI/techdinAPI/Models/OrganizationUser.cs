using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class OrganizationUser
    {
        public int OrganizationId { get; set; }
        public string UserName { get; set; }

        public Organization Organization { get; set; }
        public User User { get; set; }
    }
}
