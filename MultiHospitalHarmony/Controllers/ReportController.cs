using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IReportService _reportService;
        public ReportController(ITransactionService transactionService, IReportService reportService)
        {
            _transactionService = transactionService;
            _reportService = reportService;
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
        [HttpGet]
        public async Task<IActionResult> StockReport()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetStockReport()
        {
            var listRes = await _reportService.Getstockreport(User.GetLogingID<int>(),new GetstockreportReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return Json(listRes);
        }
        
        [HttpGet]
        public async Task<IActionResult> StockReportBatchWise()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetStockReportBatchWise()
        {
            var listRes = await _reportService.GetStockReportBatchWise(User.GetLogingID<int>(), new GetstockreportReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return Json(listRes);
        }
    }
}
