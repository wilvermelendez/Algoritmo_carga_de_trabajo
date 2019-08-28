using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(new { data = DemandService.GetDemands() });
        }
    }
}