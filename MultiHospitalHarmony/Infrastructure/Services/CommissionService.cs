using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class CommissionService: ICommissionService
    {
        private readonly IDapperContext _dapperContext;
        public CommissionService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<List<Commission>>> GetList()
        {
            var response = new AppResponse<List<Commission>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Commission>("Proc_GetCommission", null, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommissionService", "GetList", ex.Message);
                response.Success = false;
                response.Message = "Sorry there is some problem!";
            }
            return response;
        }
        public async Task<AppResponse<object>> Save(CommissionReq commissionReq)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveCommission", commissionReq, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommissionService", "Save", ex.Message);
                response.Success = false;
                response.Message = "Sorry there is some problem!";
            }
            return response;
        }
        public async Task<AppResponse<Commission>> GetById(int Id)
        {
            var response = new AppResponse<Commission>();
            try
            {
                response.Data = await _dapperContext.ExecuteProcAsync<Commission>("Proc_GetCommission", new {Id}, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommissionService", "GetList", ex.Message);
                response.Success = false;
                response.Message = "Sorry there is some problem!";
            }
            return response;
        }
    }
}
