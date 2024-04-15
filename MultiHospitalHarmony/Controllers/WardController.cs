using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class WardController : Controller
    {
        private readonly IWardService _wardService;
        public WardController(IWardService wardService)
        {
			_wardService = wardService;
		}

		[HttpGet]
        public async Task<IActionResult> Type()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveType(AddWardTypeReq addWardTypeReq)
        {
            var res = await _wardService.AddWardType(User.GetLogingID<int>(),new AddWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = addWardTypeReq.Id,
                Name = addWardTypeReq.Name,
                Remark = addWardTypeReq.Remark,
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetWardType(GetWardTypeReq addWardTypeReq)
        {
            var res = await _wardService.GetWardType(User.GetLogingID<int>(),new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId()
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetWardTypeById(GetWardTypeReq addWardTypeReq)
        {
            addWardTypeReq.Id = addWardTypeReq.Id == 0 ? -1: addWardTypeReq.Id;
            var res = await _wardService.GetWardTypeById(User.GetLogingID<int>(), new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = addWardTypeReq.Id
            });
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetWardList(GetWardTypeReq addWardTypeReq)
        {
            var res = await _wardService.GetWardList(User.GetLogingID<int>(), new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                WardTypeId = addWardTypeReq.WardTypeId
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> Save(AddWardReq addWardReq)
        {
            var res = await _wardService.Add(User.GetLogingID<int>(), new AddWardReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = addWardReq.Id,
                Name = addWardReq.Name,
                Type = addWardReq.Type,
                Capacity_of_bed = addWardReq.Capacity_of_bed,
                Charge = addWardReq.Charge,
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddHospitalBeds(AddHospitalBedsReq bedsReq)
        {
            var res = await _wardService.AddHospitalBeds(User.GetLogingID<int>(), new AddHospitalBedsReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = bedsReq.Id,
                Name = bedsReq.Name,
                Code = bedsReq.Code,
                WardId = bedsReq.WardId
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetWardById(GetWardTypeReq addWardTypeReq)
        {
            addWardTypeReq.Id = addWardTypeReq.Id == 0 ? -1 : addWardTypeReq.Id;
            var res = await _wardService.GetWardById(User.GetLogingID<int>(), new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = addWardTypeReq.Id
            });
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> AddBeds(int wardId)
        {
            var res = new AddBedsVM();
            res.WardDetails = await _wardService.GetWardById(User.GetLogingID<int>(), new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                Id = wardId
            });
            res.HospitalBeds = await _wardService.GetHospitalBeds(User.GetLogingID<int>(), new GetBedsReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                WardId = wardId
            });
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetHospitalBedById(GetBedsReq getBedsReq)
        {
            var res = await _wardService.GetHospitalBeds(User.GetLogingID<int>(), new GetBedsReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                WardId = getBedsReq.WardId,
                Id = getBedsReq.Id
            });
            return Json(res);
        }
    }
}
