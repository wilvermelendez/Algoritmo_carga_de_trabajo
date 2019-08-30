using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET_Core_2_1.Controllers.Api
{
    [Route("api/[controller]")]
    public class DemandDTController : ControllerBase
    {
        public IDemandService DemandService { get; set; }
        public DemandDTController(IDemandService demandService)
        {
            DemandService = demandService;
        }

        [HttpGet]
        public IActionResult Demands()
        {
            var data = DemandService.GetDemandsDT();
            return Ok(new { data, Id = data.Select(x => x.Id).ToList(), Month = data.Select(x => x.Month).ToList(), Jobs = data.Select(x => x.Jobs).ToList(), Salario = data.Select(x => x.Salario).ToList(), PenaltySalary = data.Select(x => x.PenaltySalary).ToList() });
        }
    }
}
