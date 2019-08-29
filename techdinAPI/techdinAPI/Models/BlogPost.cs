using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class BlogPost
    {
        public int PostId { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public User User { get; set; }
    }
}
