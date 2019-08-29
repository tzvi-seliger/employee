using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProfileBuilder.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int AcctType { get; set; }
        public string Email { get; set; }
        public string Header { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImagePath { get; set; }
        public string ResumePath { get; set; }
        public string LinkedIn { get; set; }
        public string Repository { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public int Views { get; set; }
        public int CohortID { get; set; }
        public string InvitationCode { get; set; }
        public string AuthToken { get; set; }

        public List<Project> ProjectList = new List<Project>();
        public List<Institution> InstitutionList = new List<Institution>();
        public List<Skill> SkillsList = new List<Skill>();
        public Cohort UserCohort = new Cohort();
    }
}
