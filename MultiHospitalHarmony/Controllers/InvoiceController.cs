using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;

namespace MultiHospitalHarmony.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet]
        public IActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveInvoice(AddInvoiceReq addInvoiceReq)
        {
            addInvoiceReq.HospitalId = User.GetHospitalId();
            addInvoiceReq.WID = User.GetWID<int>();
            var res = await _invoiceService.Add(User.GetLogingID<int>(), addInvoiceReq);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetInvoiceItem(GetInvoiceItemReq getInvoiceItemReq)
        {
            getInvoiceItemReq.HospitalId = User.GetHospitalId();
            getInvoiceItemReq.WID = User.GetWID<int>();
            var res = await _invoiceService.GetInvoiceItem(User.GetLogingID<int>(), getInvoiceItemReq);
            return Json(res);
        }
        [HttpGet]
        public IActionResult InvoiceList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetInvoiceList(GetInvoiceListReq getInvoiceListReq)
        {
            getInvoiceListReq.HospitalId = User.GetHospitalId();
            getInvoiceListReq.WID = User.GetWID<int>();
            var res = await _invoiceService.GetInvoiceList(User.GetLogingID<int>(), getInvoiceListReq);
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> ViewInvoice(int invoiceId)
        {
            var res = await _invoiceService.GetInvoiceDetail(User.GetLogingID<int>(),new GetInvoiceDetailsReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                InvoiceId = invoiceId
            });
            var customerDetails = JsonConvert.DeserializeObject<List<InvoiceTo>>(res.Data.CustomerDetailJson);
            res.Data.CustomerDetail = customerDetails.FirstOrDefault();
            var pharmacyList = JsonConvert.DeserializeObject<List<InvoiceFrom>>(res.Data.PharmacyDetailsJson);
            res.Data.PharmacyDetails = pharmacyList.FirstOrDefault();
            res.Data.InvoiceDetail = JsonConvert.DeserializeObject<List<InvoiceItems>>(res.Data.InvoiceDetailsJson);
            return View(res);
        }

    }
}
