using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<AppResponse<Users>> Login(LoginRequest loginRequest);
    }
}
