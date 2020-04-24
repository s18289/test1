using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test1.Services;

namespace test1.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IDbService _dbService;

        public ProjectsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            return Ok();
        }
    }
}