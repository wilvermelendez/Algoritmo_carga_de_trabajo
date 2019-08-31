using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_2_1.DTO;
using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        public IWorkLoadService WorkLoadService { get; set; }

        public OperatorController(IWorkLoadService workLoadService)
        {
            WorkLoadService = workLoadService;
        }

        [HttpGet]
        public IActionResult GetOperatorsPerMonths()
        {
            var data = WorkLoadService.GetWorkLoads().Select(x=>new OperatorPerMonth{Month =x.Month, OperatorQuantity = x.Operators.Count(), DemandPerMonth=x.Demand, JobsPerOperatorPerMonth = x.JobsPerOperatorPerMonth }).ToList();
            
            return Ok(new{data});
        }

    }
}