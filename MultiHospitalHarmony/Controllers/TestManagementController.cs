using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
	[Authorize]
	public class TestManagementController : Controller
	{
		private readonly ITestManagementService _testManagementService;
		public TestManagementController(ITestManagementService testManagementService)
		{
            _testManagementService = testManagementService;
        }
        [HttpGet]
		public async Task<IActionResult> TestCategory()
		{
			var res = await _testManagementService.GetLaboratoryTestCategory(User.GetLogingID<int>(),new GetLaboratoryTestCategoryReq
			{
				HospitalId = User.GetHospitalId(),
				WID = User.GetWID<int>()
			});
            return View(res);
		}
        [HttpPost]
        public async Task<IActionResult> SaveTestCategory(AddLaboratoryTestCategoryReq addLaboratoryTest)
        {
			addLaboratoryTest.HospitalId = User.GetHospitalId();
			addLaboratoryTest.WID = User.GetWID<int>();
            var res = await _testManagementService.SaveLaboratoryTestCategory(User.GetLogingID<int>(), addLaboratoryTest);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetTestCategoryById(int Id)
        {
            Id = Id == 0 ? -1 : Id;
            var res = await _testManagementService.GetLaboratoryTestCategory(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }
        [HttpGet]
		public async Task<IActionResult> Tests()
		{
            var model = new TestsVM();
            model.TestCategory = await _testManagementService.GetLaboratoryTestCategory(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            model.LaboratoryTest = await _testManagementService.GetLaboratoryTest(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> GetLaboratoryTestById(int Id)
        {
            Id = Id == 0 ? -1 : Id;
            var res = await _testManagementService.GetLaboratoryTest(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> SaveTest(LaboratoryTestReq laboratoryTestReq)
        {
            laboratoryTestReq.HospitalId = User.GetHospitalId();
            laboratoryTestReq.WID = User.GetWID<int>();
            var res = await _testManagementService.SaveLaboratoryTest(User.GetLogingID<int>(), laboratoryTestReq);
            return Json(res);
        }
        [HttpPost(nameof(BindTestCategory))]
        public async Task<IActionResult> BindTestCategory()
        {
            var res = await _testManagementService.GetLaboratoryTestCategory(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return Json(res);
        }
        [HttpPost(nameof(BindTest))]
        public async Task<IActionResult> BindTest(int categoryId)
        {
            var res = await _testManagementService.GetLaboratoryTest(User.GetLogingID<int>(), new GetLaboratoryTestCategoryReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            res.Data = res.Data.Where(x => x.CategoryId == categoryId).ToList();
            return Json(res);
        }
    }
}
