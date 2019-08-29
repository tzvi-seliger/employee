using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class Education
    {
        public int EduId { get; set; }
        public string UserName { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public string Grade { get; set; }
        public string Description { get; set; }
        public string ActivitiesSocieties { get; set; }

        public Organization Organization { get; set; }
        public User User { get; set; }
    }
}
