using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IReportService _reportService;
        private readonly IInvoiceService _invoiceService;
        public ReportController(ITransactionService transactionService, IReportService reportService, IInvoiceService invoiceService)
        {
            _transactionService = transactionService;
            _reportService = reportService;
            _invoiceService = invoiceService;
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
        [HttpGet]
        public IActionResult SaleReportMonthWise()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetSaleReportMonthWise(int Year)
        {
            var res = await _invoiceService.GetSaleReportMonthWise(User.GetLogingID<int>(), new GetSaleReportMonthWiseReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Year = Year
            });
            return PartialView(res);
        }
        [HttpGet]
        public IActionResult PurchaseReportMonthWise()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPurchaseReportMonthWise(int Year)
        {
            var res = await _invoiceService.GetPurchaseReportMonthWise(User.GetLogingID<int>(), new GetSaleReportMonthWiseReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Year = Year
            });
            return PartialView(res);
        }
    }
}
