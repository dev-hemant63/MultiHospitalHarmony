using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class DashboardService: IDashboardServices
    {
        private readonly IDapperContext _dapperContext;
        public DashboardService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<PharmacyDashboardData>> GetPharmacyDashboardData(int loginId,GetPharmacyDashboardDataReq dashboardDataReq)
        {
            var res = new AppResponse<PharmacyDashboardData>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<PharmacyDashboardData>("Proc_GetPharmacyDashboardData",new
                {
                    loginId,
                    dashboardDataReq.WID,
                    dashboardDataReq.HospitalId
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("DashboardService", "GetPharmacyDashboardData", ex.Message);
            }
            return res;
        }
    }
}
