using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class OperationTheatreController : Controller
    {
        private readonly IOperationTheatreService _operationTheatreService;
        private readonly IUserService _userService;
        public OperationTheatreController(IOperationTheatreService operationTheatreService, IUserService userService)
        {
            _operationTheatreService = operationTheatreService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Surgeries()
        {
            var res = await _operationTheatreService.GetSurgeries(User.GetLogingID<int>(),new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSurgeries(SaveSurgeriesReq surgeriesReq)
        {
            surgeriesReq.HospitalId = User.GetHospitalId();
            surgeriesReq.WID = User.GetWID<int>();
            var res = await _operationTheatreService.SaveSurgeries(User.GetLogingID<int>(), surgeriesReq);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetSurgerieById(GetSurgeriesReq surgeriesReq)
        {
            surgeriesReq.HospitalId = User.GetHospitalId();
            surgeriesReq.WID = User.GetWID<int>();
            var res = await _operationTheatreService.GetSurgeriesById(User.GetLogingID<int>(), surgeriesReq);
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> SurgerieDoctorMaping()
        {
            var model = new SurgerieDoctorMapingVM();
            var res = await _userService.GetDoctorList(User.GetLogingID<int>(), new GetDoctorReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            var res2 = await _operationTheatreService.GetSurgeries(User.GetLogingID<int>(), new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            var res3 = await _operationTheatreService.GetDoctorAndSurgery(User.GetLogingID<int>(), new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            model.Doctors = res.Data;
            model.Surgeries = res2.Data;
            model.DoctorAndSurgery = res3.Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DoctorSurgerieMapping(DoctorSurgerieMapingReq mapingReq)
        {
            mapingReq.HospitalId = User.GetHospitalId();
            mapingReq.WID = User.GetWID<int>();
            var res = await _operationTheatreService.DoctorSurgerieMaping(User.GetLogingID<int>(), mapingReq);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetDoctorSurgeryById(int Id)
        {
            var res = await _operationTheatreService.GetDoctorAndSurgery(User.GetLogingID<int>(), new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }
    }
}
