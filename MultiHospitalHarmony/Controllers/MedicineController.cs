using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _mediicineService;
        private ISupplierService _supplierService;
        private IFileUploadService _fileUploadService;
        public MedicineController(IMedicineService medicineService, ISupplierService supplierService, IFileUploadService fileUploadService)
        {
            _mediicineService = medicineService;
            _supplierService = supplierService;
            _fileUploadService = fileUploadService;
        }
        [HttpGet]
        public IActionResult Unit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveUnit(MedicineUnitReq medicineUnitReq)
        {
            var res = await _mediicineService.SaveUnit(User.GetLogingID<int>(), new MedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Name = medicineUnitReq.Name,
                IsActive = medicineUnitReq.IsActive,
                Id = medicineUnitReq.Id,
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetUnit()
        {
            var res = await _mediicineService.GetUnit(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetUnitById(int Id)
        {
            var res = await _mediicineService.GetUnitById(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }

        [HttpGet]
        public IActionResult Type()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveType(MedicineUnitReq medicineUnitReq)
        {
            var res = await _mediicineService.SaveType(User.GetLogingID<int>(), new MedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Name = medicineUnitReq.Name,
                IsActive = medicineUnitReq.IsActive,
                Id = medicineUnitReq.Id,
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetType()
        {
            var res = await _mediicineService.GetType(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetTypeById(int Id)
        {
            var res = await _mediicineService.GetTypeById(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }
        [HttpGet]
        public IActionResult LeafSetting()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveLeafSetting(AddLeafSettingReq addLeafSetting)
        {
            var res = await _mediicineService.SaveLeafSetting(User.GetLogingID<int>(), new AddLeafSettingReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                LeafType = addLeafSetting.LeafType,
                Id = addLeafSetting.Id,
                TotalNumber = addLeafSetting.TotalNumber,
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetLeafSetting()
        {
            var res = await _mediicineService.GetLeafSetting(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetLeafSettingById(int Id)
        {
            var res = await _mediicineService.GetLeafSettingById(User.GetLogingID<int>(), new GetMedicineUnitReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> AddMedicine(int Id)
        {
            Id = Id == 0 ? -1 : Id;
            var res = await _mediicineService.GetMedicineList(User.GetLogingID<int>(), new GetMedicineFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            var data = res.Data.FirstOrDefault() ?? new Medicine();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetMedicineCategory()
        {
            var res = await _mediicineService.GetMedicineCategory();
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetSupliers()
        {
            var response = await _supplierService.List(User.GetLogingID<int>(), new CommonFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                SearchCriteria = Enum.SearchCriteria.None,
                SearchText = "",
            });
            return Json(response);
        }
        [HttpGet]
        public async Task<IActionResult> MedicineList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetMedicineList()
        {
            var res = await _mediicineService.GetMedicineList(User.GetLogingID<int>(), new GetMedicineFilter
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = 0
            });
            return PartialView(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddMedicine(string jsonData, IFormFile file)
        {
            var addMedicineReq = JsonConvert.DeserializeObject<AddMedicineReq>(jsonData);
            addMedicineReq.Image = file;
            if (addMedicineReq.Image != null)
            {
                var fileRes = _fileUploadService.Upload(new FileUploadModel
                {
                    file = addMedicineReq.Image,
                    FileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff"),
                    FilePath = $"wwwroot/upload/pharmacy/{User.GetLogingID<int>()}/Medicine/"
                });
                if (!fileRes.Success)
                {
                    return Json(fileRes);
                }
                addMedicineReq.ImageUrl = fileRes.Data;
            }
            var res = await _mediicineService.AddMedicine(User.GetLogingID<int>(), new AddMedicineReq
            {
                Id = addMedicineReq.Id,
                WID = User.GetWID<int>(),
                HospitalId = User.GetHospitalId(),
                BarCode = addMedicineReq.BarCode,
                SupplierId = addMedicineReq.SupplierId,
                CategoryId = addMedicineReq.CategoryId,
                MedicineType = addMedicineReq.MedicineType,
                Name = addMedicineReq.Name,
                Strength = addMedicineReq.Strength,
                GenericName = addMedicineReq.GenericName,
                BoxSize = addMedicineReq.BoxSize,
                UnitId = addMedicineReq.UnitId,
                Shelf = addMedicineReq.Shelf,
                Details = addMedicineReq.Details,
                Price = addMedicineReq.Price,
                ImageUrl = addMedicineReq.ImageUrl,
                SupplierPrice = addMedicineReq.SupplierPrice,
                TaxInPercentage = addMedicineReq.TaxInPercentage,
                PricePerUnit = addMedicineReq.PricePerUnit,
            });
            return Json(res);
        }
    }
}
