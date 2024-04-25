using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IPurchaseService
    {
        Task<AppResponse<object>> SaveMedicinePurchase(int LoginId, MedicinePurchaseReq medicinePurchaseReq);
        Task<AppResponse<List<MedicinePurchase>>> GetMedicinePurchase(int loginId, GetMedicinePurchasReq request);
    }
}
