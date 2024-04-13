using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<AppResponse<object>> Create(Users users, int loginId,int WId);
        Task<AppResponse<List<Users>>> GetUserList(int loginId, GetUserFilter userFilter);
        Task<AppResponse<CreateUserVM>> GetUserById(int loginId, int Id);
        Task<AppResponse<List<Qualifications>>> GetUserQualifications(int loginId);
        Task<AppResponse<List<MedicalHistory>>> MedicalHistory(int loginId);
        Task<AppResponse<object>> SaveMedicalHistory(int loginId, MedicalHistory medicalHistory);
        Task<AppResponse<List<UserPermisions>>> GetPermisions(int UserId);
        Task<AppResponse<object>> AssignPermission(int UserId, int ModuleId);
        Task<AppResponse<CreateUserVM>> GetUserByMobile(string mobileNo);
        Task<AppResponse<List<Users>>> GetDoctorList(int loginId, GetDoctorReq userFilter);
    }
}
