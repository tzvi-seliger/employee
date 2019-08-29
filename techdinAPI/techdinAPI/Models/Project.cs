using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectAttachments = new HashSet<ProjectAttachment>();
            ProjectUser = new HashSet<ProjectUser>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<ProjectAttachment> ProjectAttachments { get; set; }
        public ICollection<ProjectUser> ProjectUser { get; set; }
    }
}
