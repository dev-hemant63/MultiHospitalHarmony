using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICommonService _commonService;
        public CustomerController(ICustomerService customerService, ICommonService commonService)
        {
            _customerService = customerService;
            _commonService = commonService;
        }
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var data = new CreateUserVM
            {
                State = new List<State>(),
                City = new List<City>(),
                ApplicationRole = new List<ApplicationRole>()
            };
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
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetCustomerList()
        {
            var res = await _customerService.List(User.GetLogingID<int>(), new GetCustomersReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
            });
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCustomer(AddUpdateCustomerReq addUpdateCustomerReq)
        {
            addUpdateCustomerReq.WID = User.GetWID<int>();
            addUpdateCustomerReq.HospitalId = User.GetHospitalId();
            var res = await _customerService.Save(User.GetLogingID<int>(), addUpdateCustomerReq);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetByCustomerId(int Id)
        {
            var res = await _customerService.List(User.GetLogingID<int>(), new GetCustomersReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>(),
                Id = Id
            });
            return Json(res.Data.FirstOrDefault());
        }
    }
}
