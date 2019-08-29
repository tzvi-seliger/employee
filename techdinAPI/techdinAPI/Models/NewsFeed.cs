using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class NewsFeed
    {
        public int ChangeId { get; set; }
        public string UserName { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeType { get; set; }

        public User User { get; set; }
    }
}
