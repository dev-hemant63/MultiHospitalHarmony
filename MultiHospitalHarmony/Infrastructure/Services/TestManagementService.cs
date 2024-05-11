using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class TestManagementService: ITestManagementService
    {
        private readonly IDapperContext _dapperContext;
        public TestManagementService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> SaveLaboratoryTestCategory(int loginId,AddLaboratoryTestCategoryReq addLaboratory)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateLaboratoryTestCategory",new
                {
                    loginId,
                    addLaboratory.WID,
                    addLaboratory.HospitalId,
                    addLaboratory.Name,
                    addLaboratory.Remark,
                    addLaboratory.Id,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TestManagementService", "SaveLaboratoryTestCategory", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<AddLaboratoryTestCategoryReq>>> GetLaboratoryTestCategory(int loginId, GetLaboratoryTestCategoryReq testCategoryReq)
        {
            var res = new AppResponse<List<AddLaboratoryTestCategoryReq>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<AddLaboratoryTestCategoryReq>("Proc_GetLaboratoryTestCategory", new
                {
                    loginId,
                    testCategoryReq.WID,
                    testCategoryReq.HospitalId,
                    testCategoryReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TestManagementService", "GetLaboratoryTestCategory", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> SaveLaboratoryTest(int loginId, LaboratoryTestReq laboratoryTestReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveLaboratoryTest", new
                {
                    loginId,
                    laboratoryTestReq.WID,
                    laboratoryTestReq.HospitalId,
                    laboratoryTestReq.Name,
                    laboratoryTestReq.Remark,
                    laboratoryTestReq.CategoryId,
                    laboratoryTestReq.Price,
                    laboratoryTestReq.Id,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TestManagementService", "SaveLaboratoryTest", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<LaboratoryTestReq>>> GetLaboratoryTest(int loginId, GetLaboratoryTestCategoryReq testCategoryReq)
        {
            var res = new AppResponse<List<LaboratoryTestReq>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<LaboratoryTestReq>("Proc_GetLaboratoryTest", new
                {
                    loginId,
                    testCategoryReq.WID,
                    testCategoryReq.HospitalId,
                    testCategoryReq.Id,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TestManagementService", "GetLaboratoryTest", ex.Message);
            }
            return res;
        }
    }
}
