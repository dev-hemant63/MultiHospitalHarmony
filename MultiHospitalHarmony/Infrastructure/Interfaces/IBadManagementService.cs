using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IBadManagementService
    {
        Task<AppResponse<object>> Save(int loginId, BadsReq badsReq);
    }
}
