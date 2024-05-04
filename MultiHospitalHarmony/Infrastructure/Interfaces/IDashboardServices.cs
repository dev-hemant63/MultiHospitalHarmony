using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IDashboardServices
    {
        Task<AppResponse<PharmacyDashboardData>> GetPharmacyDashboardData(int loginId, GetPharmacyDashboardDataReq dashboardDataReq);
    }
}
