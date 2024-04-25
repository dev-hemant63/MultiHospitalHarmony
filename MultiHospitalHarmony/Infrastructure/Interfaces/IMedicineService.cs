using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IMedicineService
    {
        Task<AppResponse<object>> SaveUnit(int loginId, MedicineUnitReq medicineUnitReq);
        Task<AppResponse<List<MedicineUnit>>> GetUnit(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<MedicineUnit>> GetUnitById(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<object>> SaveType(int loginId, MedicineUnitReq medicineUnitReq);
        Task<AppResponse<List<MedicineUnit>>> GetType(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<MedicineUnit>> GetTypeById(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<object>> SaveLeafSetting(int loginId, AddLeafSettingReq addLeafSettingReq);
        Task<AppResponse<List<LeafSetting>>> GetLeafSetting(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<LeafSetting>> GetLeafSettingById(int loginId, GetMedicineUnitReq medicineUnitReq);
        Task<AppResponse<List<MedicineCategory>>> GetMedicineCategory();
        Task<AppResponse<object>> AddMedicine(int loginId, AddMedicineReq addMedicineReq);
        Task<AppResponse<List<Medicine>>> GetMedicineList(int loginId, GetMedicineFilter getMedicineFilter);
    }
}
