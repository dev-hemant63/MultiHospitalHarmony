using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiHospitalHarmony.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize (Roles ="SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> SuperAdmin()
        {
            return View();
        }
    }
}
