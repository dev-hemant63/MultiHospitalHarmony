using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private ICommonService _commonService;
        private IFileUploadService _fileUploadService;
        public UserController(IUserService userService, ICommonService commonService, IFileUploadService fileUploadService)
        {
            _userService = userService;
            _commonService = commonService;
            _fileUploadService = fileUploadService;
        }
        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var data = new CreateUserVM
            {
                State = new List<State>(),
                City = new List<City>(),
                ApplicationRole = new List<ApplicationRole>()
            };
            if (Id != 0)
            {
                var userRes = await _userService.GetUserById(Id, Id);
                if (userRes.Success)
                {
                    data = userRes.Data;
                }
            }
            var cityRes = await _commonService.GetCity();
            if (cityRes.Success)
            {
                data.City = cityRes.Data;
            }
            var stateRes = await _commonService.GetState();
            if (stateRes.Success)
            {
                data.State = stateRes.Data;
            }
            var roleRes = await _commonService.GetUserRole(User.GetLogingID<int>());
            if (roleRes.Success)
            {
                data.ApplicationRole = roleRes.Data;
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string jsonData)
        {
            var request = JsonConvert.DeserializeObject<Users>(jsonData);
            var res = await _userService.Create(request, User.GetLogingID<int>());
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserList(GetUserFilter userFilter)
        {
            var data = await _userService.GetUserList(User.GetLogingID<int>(), userFilter);
            if (data.Success)
            {
                return PartialView(data.Data);
            }
            return PartialView("~/home/recordnotfound");
        }
        [HttpGet]
        public async Task<IActionResult> profile()
        {
            var userRes = await _userService.GetUserById(User.GetLogingID<int>(), User.GetLogingID<int>());
			var cityRes = await _commonService.GetCity();
			if (cityRes.Success)
			{
				userRes.Data.City = cityRes.Data;
			}
			var stateRes = await _commonService.GetState();
			if (stateRes.Success)
			{
				userRes.Data.State = stateRes.Data;
			}
			return View(userRes.Data);
        }
        [HttpGet]
        public async Task<IActionResult> forgetpassword()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var model = new PatientDeatilsVM
            {
                BasicDetails = new Users(),
                MedicalHistory = new List<MedicalHistory>()
            };
            var userRes = await _userService.GetUserById(User.GetLogingID<int>(), Id);
            if (userRes.Success)
            {
                model.BasicDetails = userRes.Data;
            }
            var medicalHistory = await _userService.MedicalHistory(Id);
            if (medicalHistory.Success)
            {
                model.MedicalHistory = medicalHistory.Data;
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Patientlist()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveMedicalHistory(string jsonData,IFormFile file)
        {
            var response = new AppResponse<object>();
            var medicalHistory = JsonConvert.DeserializeObject<MedicalHistory>(jsonData);
            if (file != null)
            {
                var fileRes = _fileUploadService.Upload(new FileUploadModel
                {
                    file = file,
                    FileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff"),
                    FilePath = "wwwroot/upload/patient/PrescriptionFile/"
                });
                if (!fileRes.Success)
                {
                    response.Message = fileRes.Message;
                    return Json(response);
                }
                medicalHistory.PrescriptionFile = fileRes.Data;
            }
            response = await _userService.SaveMedicalHistory(User.GetLogingID<int>(),medicalHistory);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetPatientList()
        {
            var data = await _userService.GetUserList(User.GetLogingID<int>(),new GetUserFilter
            {
                RoleId = AppRole.Patient
            });
            if (data.Success)
            {
                return PartialView(data.Data);
            }
            return PartialView("~/home/recordnotfound");
        }
    }
}
