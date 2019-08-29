using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProfileBuilder.Models
{
    public class Cohort
    {
        public int CohortID { get; set; }
        public string Location { get; set; }
        public string Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
