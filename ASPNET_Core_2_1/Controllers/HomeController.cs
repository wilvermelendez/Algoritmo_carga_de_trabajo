using ASPNET_Core_2_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers
{
    public class HomeController : Controller
    {
        public IWorkLoadService WorkLoadService { get; set; }

        public HomeController(IWorkLoadService workLoadService)
        {
            WorkLoadService = workLoadService;
        }
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Minor()
        {

            return View();
        }

    }
}
