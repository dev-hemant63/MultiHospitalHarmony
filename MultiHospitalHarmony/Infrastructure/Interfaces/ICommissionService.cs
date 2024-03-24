using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ICommissionService
    {
        Task<AppResponse<List<Commission>>> GetList();
        Task<AppResponse<object>> Save(CommissionReq commissionReq);
        Task<AppResponse<Commission>> GetById(int Id);
    }
}
