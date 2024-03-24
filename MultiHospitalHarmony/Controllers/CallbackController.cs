using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using System.Text;

namespace MultiHospitalHarmony.Controllers
{
    public class CallbackController : Controller
    {
        private readonly ITransactionService _transactionService;
        public CallbackController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet("callback/uniquepayupi")]
        public async Task<IActionResult> CallbackUniuePayUPI(string requestedId, int tid, string status, string utr, decimal amount)
        {
            _ = await _transactionService.UpdateStatus(Convert.ToInt32(requestedId), status[0].ToString(),utr);

            StringBuilder html = new StringBuilder(@"<html><head><script>
                        (()=>{
                                var obj={TID:""{TID}"",Amount:""{Amount}"",Remark:""{Remark}"",status:""{status}"",origin:""Package""}
                                localStorage.setItem('obj', JSON.stringify(obj));
                                window.close();
                           })();</script></head><body><h6>Redirect to Portal.....</h6></body></html>");
            html.Replace("{TID}", tid.ToString());
            html.Replace("{Amount}", amount.ToString());
            html.Replace("{status}", status[0].ToString());
            html.Replace("{Remark}", utr);
            return Content(html.ToString(), contentType: "text/html; charset=utf-8");
        }
    }
}
