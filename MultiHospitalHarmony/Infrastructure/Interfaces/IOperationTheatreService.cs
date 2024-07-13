using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IOperationTheatreService
    {
        Task<AppResponse<object>> SaveSurgeries(int loginId, SaveSurgeriesReq surgeriesReq);
        Task<AppResponse<List<SaveSurgeriesReq>>> GetSurgeries(int loginId, GetSurgeriesReq surgeriesReq);
        Task<AppResponse<SaveSurgeriesReq>> GetSurgeriesById(int loginId, GetSurgeriesReq surgeriesReq);
        Task<AppResponse<object>> DoctorSurgerieMaping(int loginId, DoctorSurgerieMapingReq mapingReq);
        Task<AppResponse<List<GetDoctorAndSurgery>>> GetDoctorAndSurgery(int loginId, GetSurgeriesReq surgeriesReq);
    }
}
