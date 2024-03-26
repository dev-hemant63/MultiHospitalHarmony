using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class AddMoneyController : Controller
    {
        private readonly ITransactionService _transactionService;
        public AddMoneyController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        [HttpPost]
        public async Task<IActionResult> InitiateTxn(decimal amount)
        {
            var res = await _transactionService.InitateTxn(User.GetLogingID<int>(), amount);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> StatusCheck(int TID)
        {
            var res = await _transactionService.StatusCheck(TID);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> History()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetHistory()
        {
            var res = await _transactionService.GetAddMoneyHistory(User.GetLogingID<int>(),0);
            if (res.Success)
            {
                return PartialView(res.Data);
            }
            return PartialView("~/home/recordnotfound");
        }
    }
}
