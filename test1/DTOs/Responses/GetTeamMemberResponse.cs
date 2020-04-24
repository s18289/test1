using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.DTOs.Responses
{
    public class GetTeamMemberResponse
    {
        public int IdTeamMember { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDeadline { get; set; }
        public string ProjectName { get; set; }
        public string TaskType { get; set; }
    }
}