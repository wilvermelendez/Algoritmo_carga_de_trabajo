using System.Linq;
using ASPNET_Core_2_1.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLoadController : ControllerBase
    {
        public IWorkLoadService WorkLoadService { get; set; }
        public WorkLoadController(IWorkLoadService workLoadService)
        {
            WorkLoadService = workLoadService;
        }

        [HttpGet("{month}")]
        public IActionResult GetWorkLoad(int month)
        {
            var data = WorkLoadService.GetWorkLoads().FirstOrDefault(x => x.Month == month);
            return Ok(new {data=data.Operators, month});
        }
    }
}