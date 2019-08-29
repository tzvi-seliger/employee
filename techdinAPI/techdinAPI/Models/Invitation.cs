using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechdinAPI.Models
{
    public enum AcctType { admin = 1, staff, student, employer }

    public class Invitation
    {
        public int InvID { get; set; }
        public string Email { get; set; }
        public AcctType Type { get; set; }
        public string InvKey { get; set; }
    }
}
