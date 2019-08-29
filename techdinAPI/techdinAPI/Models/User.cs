using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            BlogPosts = new HashSet<BlogPost>();
            Education = new HashSet<Education>();
            //UserInterestsUsers = new HashSet<UserInterests>();
            UserInterests = new HashSet<UserInterests>();
            NewsFeed = new HashSet<NewsFeed>();
            OrganizationUser = new HashSet<OrganizationUser>();
            Organizations = new HashSet<Organization>();
            ProfileAttachments = new HashSet<ProfileAttachment>();
            ProjectUser = new HashSet<ProjectUser>();
            WorkExperience = new HashSet<WorkExperience>();
        }

        public string Header { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ResumePath { get; set; }
        public string LinkedIn { get; set; }
        public string Repository { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public int? Views { get; set; }
        public bool? IsActive { get; set; }

        public Cohort Cohort { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<Education> Education { get; set; }
        //public ICollection<UserInterests> UserInterestsUsers { get; set; }
        public ICollection<UserInterests> UserInterests { get; set; }
        public ICollection<NewsFeed> NewsFeed { get; set; }
        public ICollection<OrganizationUser> OrganizationUser { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<ProfileAttachment> ProfileAttachments { get; set; }
        public ICollection<ProjectUser> ProjectUser { get; set; }
        public ICollection<WorkExperience> WorkExperience { get; set; }
    }
}
