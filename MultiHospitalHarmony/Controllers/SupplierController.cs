using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private ICommonService _commonService;
        private ISupplierService _supplierService;
        public SupplierController(ICommonService commonService, ISupplierService supplierService)
        {
            _commonService = commonService;
            _supplierService = supplierService;
        }
        [HttpGet]
        public async Task<IActionResult> Add(int Id)
        {
            var model = new SupplierVM();
            var cityRes = await _commonService.GetCity();
            if (cityRes.Success)
            {
                model.City = cityRes.Data;
            }
            var stateRes = await _commonService.GetState();
            if (stateRes.Success)
            {
                model.State = stateRes.Data;
            }
            if (Id != 0)
            {
                var data = await _supplierService.GetById(User.GetLogingID<int>(), Id);
                model.Id = data.Data.Id;
                model.Name = data.Data.Name;
                model.MobileNo = data.Data.MobileNo;
                model.EmailId = data.Data.EmailId;
                model.Pincode = data.Data.Pincode;
                model.Address = data.Data.Address;
                model.StateId = data.Data.StateId;
                model.CityId = data.Data.CityId;
                model.Tahsil = data.Data.Tahsil;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSupplier(AddSupplierReq supplierReq)
        {
            var response = await _supplierService.Save(User.GetLogingID<int>(), new AddSupplierReq
            {
                Id = supplierReq.Id,
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Name = supplierReq.Name,
                MobileNo = supplierReq.MobileNo,
                EmailId = supplierReq.EmailId,
                CityId = supplierReq.CityId,
                StateId = supplierReq.StateId,
                Pincode = supplierReq.Pincode,
                Tahsil = supplierReq.Tahsil,
                Address = supplierReq.Address,
            });
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetSupplier(CommonFilter commonFilter)
        {
            var response = await _supplierService.List(User.GetLogingID<int>(), new CommonFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                SearchCriteria = commonFilter.SearchCriteria,
                SearchText = commonFilter.SearchText,
            });
            return PartialView(response);
        }
    }
}
