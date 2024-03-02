using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.Common;
using System.Collections.Specialized;
using System.Net;
using System.Web;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class SMSService: ISMSService
    {
        private readonly IApiUtilityService _apiUtilityService;
        public SMSService(IApiUtilityService apiUtilityService)
        {
            _apiUtilityService = apiUtilityService;
        }
        public async Task<AppResponse<object>> Send()
        {
            var response = new AppResponse<object>();
            string message = HttpUtility.UrlEncode("This is your message");
            using (var wb = new WebClient())
            {
                byte[] apiresponse = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "yourapiKey"},
                {"numbers" , "916390749256"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                response.Message = System.Text.Encoding.UTF8.GetString(apiresponse);
                response.Success = true;
            }
            return response;
        }
    }
}
