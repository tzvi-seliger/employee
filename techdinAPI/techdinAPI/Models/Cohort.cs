using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class Cohort
    {

        public int CohortId { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Semester { get; set; }
        public bool? IsActive { get; set; }

    }
}
