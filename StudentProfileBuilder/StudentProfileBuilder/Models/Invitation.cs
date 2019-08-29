using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProfileBuilder.Models
{
    public class Invitation
    {
        public int InvID { get; set; }
        public string Email { get; set; }
        public string InvKey { get; set; }
    }
}
