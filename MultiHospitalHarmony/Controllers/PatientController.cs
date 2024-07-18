using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IUserService _userService;
        private ICommonService _commonService;
        private IIPDService _iPDService;
        private IFileUploadService _fileUploadService;
        private readonly IWardService _wardService;
        private readonly IOperationTheatreService _operationTheatreService;
        public PatientController(IUserService userService, ICommonService commonService, IIPDService iPDService, IFileUploadService fileUploadService, IWardService wardService, IOperationTheatreService operationTheatreService)
        {
            _userService = userService;
            _commonService = commonService;
            _iPDService = iPDService;
            _fileUploadService = fileUploadService;
            _wardService = wardService;
            _operationTheatreService = operationTheatreService;
        }
        [HttpGet]
        public async Task<IActionResult> Admit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPatientDetails(string patientInfo)
        {
            var data = new CreateUserVM
            {
                State = new List<State>(),
                City = new List<City>(),
                ApplicationRole = new List<ApplicationRole>()
            };
            if (!string.IsNullOrEmpty(patientInfo))
            {
                var userRes = await _userService.GetUserByMobile(patientInfo);
                if (userRes.Success && userRes.Data != null)
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
            var WardTypeRes = await _wardService.GetWardType(User.GetLogingID<int>(), new GetWardTypeReq
            {
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId()
            });
            if (WardTypeRes.Success)
            {
                data.WardType = WardTypeRes.Data;
            }
            var dRRes = await _userService.GetDoctorList(User.GetLogingID<int>(), new GetDoctorReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            if (dRRes.Success)
            {
                data.UserList = dRRes.Data;
            }
            var surRes = await _operationTheatreService.GetDoctorAndSurgery(User.GetLogingID<int>(),new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            if (surRes.Success)
            {
                data.SurgeryList = surRes.Data;
            }
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetDoctors(GetBedsReq getBedsReq)
        {
            var res = await _userService.GetDoctorList(User.GetLogingID<int>(), new GetDoctorReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AdmitPatient(string JsonData, IFormFile File)
        {
            var req = JsonConvert.DeserializeObject<AdmitPatientReq>(JsonData);
            string fileName = "";
            if (File != null)
            {
                var fileRes = _fileUploadService.Upload(new FileUploadModel
                {
                    file = File,
                    FileName = $"{req.FullName}_{DateTime.Now.ToString("ddMMyyyyhhmmssfff")}",
                    FilePath = "wwwroot/upload/patient/PrescriptionFile/"
                });
                if (!fileRes.Success)
                {
                    return Json(fileRes);
                };
                fileName = fileRes.Data;
            }
            req.PrescriptionFile = fileName;
            req.WID = User.GetWID<int>();
            req.HospitalId = User.GetHospitalId();

            var res = await _iPDService.AdmitPatient(User.GetLogingID<int>(), req);
            return Json(res);
        }
        [HttpGet]
        public IActionResult AdmitedPatientList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAdmitedPatientList(PatientFilter patientFilter)
        {
            var res = await _iPDService.AdmitedPatientList(User.GetLogingID<int>(), new PatientFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                SearchCriteria = patientFilter.SearchCriteria,
                SearchText = patientFilter.SearchText,
            });
            return PartialView(res.Data);
        }
        [HttpPost]
        public async Task<IActionResult> GetDoctorVisit(int patientId)
        {
            var res = await _iPDService.GetDoctorVisit(User.GetLogingID<int>(), patientId);
            return PartialView(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetPatientWards(int patientId)
        {
            var res = await _iPDService.PatientWardDetails(User.GetLogingID<int>(), patientId);
            return PartialView(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetHistory(int patientId)
        {
            var medicalHistory = await _userService.MedicalHistory(patientId);
            return PartialView(medicalHistory);
        }
        [HttpGet]
        public async Task<IActionResult> Appointment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveDoctorVisit(IFormFile file,string jsonData)
        {
            var saveDoctorVisitReq = JsonConvert.DeserializeObject<SaveDoctorVisitReq>(jsonData);
            saveDoctorVisitReq.WID = User.GetWID<int>();
            saveDoctorVisitReq.HospitalId = User.GetHospitalId();
            saveDoctorVisitReq.DoctorId = User.GetDoctorId();
            var res = await _iPDService.SaveDoctorVisit(User.GetLogingID<int>(), saveDoctorVisitReq);

            if (res.Success)
            {
                var medicalHistory = JsonConvert.DeserializeObject<MedicalHistory>(jsonData);
                medicalHistory.IsFromAdmitted = true;
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
                        res.Message = fileRes.Message;
                        return Json(res);
                    }
                    medicalHistory.PrescriptionFile = fileRes.Data;
                }
                res = await _userService.SaveMedicalHistory(User.GetLogingID<int>(), medicalHistory);
            }
            return Ok(res);
        }
        [HttpPost(nameof(GetPatientDetailsForBilling))]
        public async Task<IActionResult> GetPatientDetailsForBilling(string PatientUserName)
        {
            var res = await _iPDService.GetPatientDetails(User.GetLogingID<int>(),new GetPatientDetailsReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                PatientUserName = PatientUserName
            });
            return PartialView(res);
        }
        [HttpPost]
        public async Task<IActionResult> ReleasePatient(PatientReleaseReq patientReleaseReq)
        {
            patientReleaseReq.WID = User.GetWID<int>();
            patientReleaseReq.HospitalId = User.GetHospitalId();
            var res = await _iPDService.ReleasePatient(User.GetLogingID<int>(), patientReleaseReq);
            return Json(res);
        }
    }
}
