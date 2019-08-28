using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNET_Core_2_1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        public IDemandService DemandService { get; set; }
        public DemandController(IDemandService demandService)
        {
            DemandService = demandService;
        }

        [HttpGet]
        public IActionResult Demands()
        {
            var data = DemandService.GetDemands();
            return Ok(new { data, months = data.Select(x => x.Month).ToList(), quantities = data.Select(x => x.Quantity).ToList() });
        }
    }
}