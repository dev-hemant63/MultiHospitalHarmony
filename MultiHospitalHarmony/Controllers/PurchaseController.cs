using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ICommonService _commonService;
        private readonly IPurchaseService _purchaseService;
        private readonly IMedicineService _mediicineService;
        public PurchaseController(ICommonService commonService, IPurchaseService purchaseService, IMedicineService mediicineService)
        {
            _commonService = commonService;
            _purchaseService = purchaseService;
            _mediicineService = mediicineService;
        }
        [HttpGet]
        public async Task<IActionResult> AddPurchase()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPaymentModes()
        {
            var res = await _commonService.GetPaymentModes();
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetMedicineList(int SupplierId)
        {
            var res = await _mediicineService.GetMedicineList(User.GetLogingID<int>(), new GetMedicineFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = 0
            });
            res.Data = res.Data.Where(x=>x.SupplierId == SupplierId).ToList();
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMedicinePurchase(MedicinePurchaseReq medicinePurchaseReq)
        {
            medicinePurchaseReq.WID = User.GetWID<int>();
            medicinePurchaseReq.HospitalId = User.GetHospitalId();
            var res = await _purchaseService.SaveMedicinePurchase(User.GetLogingID<int>(), medicinePurchaseReq);
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> Purchaselist()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetMedicinePurchase(GetMedicinePurchasReq getMedicinePurchasReq)
        {
            getMedicinePurchasReq.WID = User.GetWID<int>();
            getMedicinePurchasReq.HospitalId = User.GetHospitalId();
            var res = await _purchaseService.GetMedicinePurchase(User.GetLogingID<int>(), getMedicinePurchasReq);
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> ViewPurchaseDetails()
        {
            return View();
        }
    }
}
