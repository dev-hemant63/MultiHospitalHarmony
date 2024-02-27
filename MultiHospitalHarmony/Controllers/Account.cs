using Microsoft.AspNetCore.Mvc;

namespace MultiHospitalHarmony.Controllers
{
	public class Account : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
