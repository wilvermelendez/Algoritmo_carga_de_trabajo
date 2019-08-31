using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Http;
using ASPNET_Core_2_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        public IParameterService ParameterService { get; set; }
        public ParameterController(IParameterService parameterService)
        {
            ParameterService = parameterService;
        }
        [HttpGet]
        public IActionResult GetParameters()
        {
            var data = ParameterService.GetParameters();
            return Ok(new { data});
        }
        [HttpPost]
        public IActionResult SaveParameter(Parameter parameter)
        {
            var data = ParameterService.SaveParameters(parameter);
            return Ok(new { success=data});
        }
    }
}