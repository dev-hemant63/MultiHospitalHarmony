using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class AlertService: IAlertService
    {
        private readonly ISMSService _smsService;
        public AlertService(ISMSService sMSService)
        {
            _smsService = sMSService;
        }
        public async Task<AppResponse<object>> Send()
        {
            var response = new AppResponse<object>();
            return response;
        }
    }
}
