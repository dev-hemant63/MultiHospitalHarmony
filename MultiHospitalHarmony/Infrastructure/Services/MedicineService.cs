using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class MedicineService: IMedicineService
    {
        private readonly IDapperContext _dapperContext;
        public MedicineService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> SaveUnit(int loginId,MedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateMedicineUnit",new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Name,
                    medicineUnitReq.IsActive,
                    medicineUnitReq.Id,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "SaveUnit", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<MedicineUnit>>> GetUnit(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<List<MedicineUnit>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<MedicineUnit>("Proc_MedicineUnit", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetUnit", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<MedicineUnit>> GetUnitById(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<MedicineUnit>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<MedicineUnit>("Proc_MedicineUnit", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetUnitById", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> SaveType(int loginId, MedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateMedicineType", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Name,
                    medicineUnitReq.IsActive,
                    medicineUnitReq.Id,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "SaveType", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<MedicineUnit>>> GetType(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<List<MedicineUnit>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<MedicineUnit>("Proc_MedicineType", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetType", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<MedicineUnit>> GetTypeById(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<MedicineUnit>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<MedicineUnit>("Proc_MedicineType", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetTypeById", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> SaveLeafSetting(int loginId, AddLeafSettingReq addLeafSettingReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateLeafSetting", new
                {
                    PharmacyId = loginId,
                    addLeafSettingReq.WID,
                    addLeafSettingReq.HospitalId,
                    addLeafSettingReq.Id,
                    addLeafSettingReq.LeafType,
                    addLeafSettingReq.TotalNumber,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "SaveLeafSetting", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<LeafSetting>>> GetLeafSetting(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<List<LeafSetting>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<LeafSetting>("Proc_GetLeafSetting", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetLeafSetting", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<LeafSetting>> GetLeafSettingById(int loginId, GetMedicineUnitReq medicineUnitReq)
        {
            var res = new AppResponse<LeafSetting>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<LeafSetting>("Proc_GetLeafSetting", new
                {
                    PharmacyId = loginId,
                    medicineUnitReq.WID,
                    medicineUnitReq.HospitalId,
                    medicineUnitReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetLeafSettingById", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<MedicineCategory>>> GetMedicineCategory()
        {
            var res = new AppResponse<List<MedicineCategory>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<MedicineCategory>("Proc_GetMedicineCategory", null);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetMedicineCategory", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> AddMedicine(int loginId,AddMedicineReq addMedicineReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateMedicine", new
                {
                    addMedicineReq.Id,
                    addMedicineReq.WID,
                    addMedicineReq.HospitalId,
                    PharmacyId = loginId,
                    addMedicineReq.BarCode,
                    addMedicineReq.SupplierId,
                    addMedicineReq.CategoryId,
                    addMedicineReq.MedicineType,
                    addMedicineReq.Name,
                    addMedicineReq.Strength,
                    addMedicineReq.GenericName,
                    addMedicineReq.BoxSize,
                    addMedicineReq.UnitId,
                    addMedicineReq.Shelf,
                    addMedicineReq.Details,
                    addMedicineReq.Price,
                    addMedicineReq.ImageUrl,
                    addMedicineReq.SupplierPrice,
                    addMedicineReq.TaxInPercentage,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "AddMedicine", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<Medicine>>> GetMedicineList(int loginId,GetMedicineFilter getMedicineFilter)
        {
            var res = new AppResponse<List<Medicine>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Medicine>("Proc_GetMedicines", new
                {
                    PharmacyId = loginId,
                    Id = getMedicineFilter.Id,
                    WId = getMedicineFilter.WID,
                    HospitalId = getMedicineFilter.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("MedicineService", "GetMedicineList", ex.Message);
            }
            return res;
        }
    }
}
