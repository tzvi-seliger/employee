using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class ProfileAttachment
    {
        public int ProfAttId { get; set; }
        public string UserName { get; set; }
        public string FileName { get; set; }

        public User User { get; set; }
    }
}
