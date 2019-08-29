using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class ProjectUser
    {
        public int ProjectId { get; set; }
        public string UserName { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}
