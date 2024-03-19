using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using System.Linq.Expressions;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class BadManagementService: IBadManagementService
    {
        private readonly IDapperContext _dapperContext;
        public BadManagementService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Save(int loginId,BadsReq badsReq)
        {
            var response = new AppResponse<object>
            {
                Message = "Failed."
            };
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateBads",new
                {
                    loginId,
                    badsReq.Id,
                    badsReq.Name,
                    badsReq.Remark,
                    badsReq.Price
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("BadManagementService", "Save", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Bads>>> List(int loginId)
        {
            var response = new AppResponse<List<Bads>>
            {
                Message = "Failed."
            };
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Bads>("Proc_GetBads", new
                {
                    loginId,
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("BadManagementService", "List", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<Bads>> GetById(int loginId,int Id)
        {
            var response = new AppResponse<Bads>
            {
                Message = "Failed."
            };
            try
            {
                response.Data = await _dapperContext.ExecuteProcAsync<Bads>("Proc_GetBads", new
                {
                    loginId,
                    Id
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("BadManagementService", "GetById", ex.Message);
            }
            return response;
        }
    }
}
