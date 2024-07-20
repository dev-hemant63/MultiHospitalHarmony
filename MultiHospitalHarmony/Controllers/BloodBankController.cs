using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class BloodBankController : Controller
    {
        [HttpGet]
        public IActionResult BloodDonate()
        {
            return View();
        }
    }
}
