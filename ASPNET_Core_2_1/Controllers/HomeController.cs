﻿using System.IO;
using ASPNET_Core_2_1.Models;
using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers
{
    public class HomeController : Controller
    {
        public IWorkLoadService WorkLoadService { get; set; }
        public IJsonService JsonService { get; set; }

        public HomeController(IWorkLoadService workLoadService, IJsonService jsonService)
        {
            WorkLoadService = workLoadService;
            JsonService = jsonService;
        }
        public IActionResult Main()
        {
            //run algorithms
            var data = WorkLoadService.GenerateWorkLoads();
            JsonService.SaveJson<WorkLoad>(data, $"{Path.GetDirectoryName(System.IO.Path.GetFullPath("DatosGrafica.json"))}/Data/WorkLoad.json");
            return View();
        }

        public IActionResult Minor()
        {

            return View();
        }

    }
}
