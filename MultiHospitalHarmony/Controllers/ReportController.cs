using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Ledger()
        {
            return View();
        }
    }
}
