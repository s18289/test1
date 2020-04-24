using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test1.Services;

namespace test1.Controllers
{
    [Route("api/teammembers")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private IDbService _dbService;

        public TeamMembersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamMember(int id)
        {
            try
            {
                var response = _dbService.GetTeamMember(id);
                return Ok(response);
            }
            catch (SqlException)
            {
                return BadRequest("Provided id does not exist!");
            }
        }
    }
}