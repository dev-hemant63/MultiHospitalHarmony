using Microsoft.AspNetCore.Mvc;

namespace MultiHospitalHarmony.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SuperAdmin()
        {
            return View();
        }
    }
}
