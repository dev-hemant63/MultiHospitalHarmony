using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ITransactionService _transactionService;
        public ReportController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<IActionResult> Ledger()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetLedgerList()
        {
            var listRes = await _transactionService.GetLedger(User.GetLogingID<int>());
            return PartialView(listRes);
        }
    }
}
