using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ISupplierService
    {
        Task<AppResponse<object>> Save(int loginId, AddSupplierReq request);
        Task<AppResponse<List<Supplier>>> List(int loginId, CommonFilter commonFilter);
        Task<AppResponse<Supplier>> GetById(int loginId, int Id);
    }
}
