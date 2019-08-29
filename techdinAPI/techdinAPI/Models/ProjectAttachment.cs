using System;
using System.Collections.Generic;

namespace TechdinAPI.Models
{
    public partial class ProjectAttachment
    {
        public int ProjAttId { get; set; }
        public int? ProjectId { get; set; }
        public string FileName { get; set; }

        public Project Project { get; set; }
    }
}
