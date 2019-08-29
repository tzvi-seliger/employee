using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class WorkExperience
    {
        public int WorkId { get; set; }
        public string UserName { get; set; }
        public int? OrganizationId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Organization Organization { get; set; }
        public User User { get; set; }
    }
}
