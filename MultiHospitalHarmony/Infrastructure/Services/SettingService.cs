using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class SettingService : ISettingService
    {
        private readonly IDapperContext _dapperContext;
        public SettingService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<List<Module>>> GetModuleList(int loginId)
        {
            var response = new AppResponse<List<Module>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Module>("Proc_GetModules", new
                {
                    loginId
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SettingService", "GetModuleList", ex.Message);
                response.Success = false;
                response.Message = "Sorry there is some problem!";
            }
            return response;
        }
        public async Task<AppResponse<object>> SaveModule(int loginId, Module module)
        {
            var res = new AppResponse<object>
            {
                Message = "Failed."
            };
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveModule", new
                {
                    loginId,
                    module.Id,
                    module.Name,
                    module.DisplayName,
                }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SettingService", "SaveModule", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<Module>> GetModuleById(int Id)
        {
            var res = new AppResponse<Module>
            {
                Message = "Failed."
            };
            try
            {
                string query = "select 1 success,'Success' [Message], * from MasterModule where Id = @Id";
                res.Data = await _dapperContext.ExecuteProcAsync<Module>(query, new
                {
                    Id,
                }, CommandType.Text);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SettingService", "GetModuleById", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<MasterPage>>> GetPageList(int moduleId)
        {
            var response = new AppResponse<List<MasterPage>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<MasterPage>("select * from MasterPages Where ModuleId = @moduleId", new
                {
                    moduleId
                }, CommandType.Text);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SettingService", "GetPageList", ex.Message);
                response.Success = false;
                response.Message = "Sorry there is some problem!";
            }
            return response;
        }
    }
}
