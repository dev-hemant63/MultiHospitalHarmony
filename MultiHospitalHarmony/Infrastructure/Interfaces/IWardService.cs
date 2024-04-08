using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IWardService
    {
		Task<AppResponse<object>> Add(int loginId, AddWardReq addWardReq);
		Task<AppResponse<object>> AddWardType(int loginId, AddWardTypeReq request);
        Task<AppResponse<List<WardType>>> GetWardType(int loginId, GetWardTypeReq request);
        Task<AppResponse<WardType>> GetWardTypeById(int loginId, GetWardTypeReq request);
        Task<AppResponse<List<Wards>>> GetWardList(int loginId, GetWardTypeReq request);
        Task<AppResponse<Wards>> GetWardById(int loginId, GetWardTypeReq request);

    }
}
