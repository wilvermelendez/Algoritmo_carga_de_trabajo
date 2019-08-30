using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_1.Controllers
{
    public class HomeController : Controller
    {
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
