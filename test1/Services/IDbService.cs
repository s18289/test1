using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test1.DTOs.Responses;

namespace test1.Services
{
    public interface IDbService
    {
        List<GetTeamMemberResponse> GetTeamMember(int id);
        IActionResult DeleteProject(int id);
    }
}