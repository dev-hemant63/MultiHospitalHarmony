using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Middleware
{
    public class VerifyHost
    {
        private readonly RequestDelegate _next;
        private readonly ICommonService _commonService;
        public VerifyHost(RequestDelegate next, ICommonService commonService)
        {
            _next = next;
            _commonService = commonService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
			if (context.Request.Path == "/Home/NotFound")
			{
				await _next(context);
			}
			var appsetting = context.RequestServices.GetService<AppSettings>();
            var domain = context.Request.Host.Value;
            if (domain.Contains("localhost"))
            {
                domain = appsetting.HostName;
            }
            var response = await _commonService.VerifyHost(domain);
            if (response.Success)
            {
                context.Request.Headers["WId"] = response.Data.ToString();
            }
            else
            {
                context.Response.Redirect($"/Home/NotFound");
				return;
            }
            await _next(context);
        }
    }
}
