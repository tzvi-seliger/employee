using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Education = new HashSet<Education>();
            OrganizationUser = new HashSet<OrganizationUser>();
            WorkExperience = new HashSet<WorkExperience>();
        }

        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }

        public User User { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<OrganizationUser> OrganizationUser { get; set; }
        public ICollection<WorkExperience> WorkExperience { get; set; }
    }
}
