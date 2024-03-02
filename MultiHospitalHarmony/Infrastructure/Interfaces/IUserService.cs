using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<AppResponse<object>> Create(Users users, int loginId);
        Task<AppResponse<List<Users>>> GetUserList(int loginId);
        Task<AppResponse<CreateUserVM>> GetUserById(int loginId, int Id);
    }
}
