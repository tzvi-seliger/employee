using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class UserInterests
    {
        public string UserName { get; set; }
        public string InterestName { get; set; }

        public User User { get; set; }
        public User Interest { get; set; }
    }
}
