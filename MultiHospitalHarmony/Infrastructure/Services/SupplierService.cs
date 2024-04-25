using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly IDapperContext _dapperContext;
        public SupplierService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Save(int loginId,AddSupplierReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateSupplier", new
                {
                    loginId,
                    request.Id,
                    request.WID,
                    request.HospitalId,
                    request.Name,
                    request.MobileNo,
                    request.EmailId,
                    request.CityId,
                    request.StateId,
                    request.Pincode,
                    request.Tahsil,
                    request.Address,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SupplierService", "Save", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Supplier>>> List(int loginId,CommonFilter commonFilter)
        {
            var response = new AppResponse<List<Supplier>>
            {
                Message = "Failed."
            };
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Supplier>("Proc_GetSupplier", new
                {
                    loginId,
                    commonFilter.WID,
                    commonFilter.HospitalId,
                    commonFilter.SearchCriteria,
                    commonFilter.SearchText
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SupplierService", "List", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<Supplier>> GetById(int loginId, int Id)
        {
            var response = new AppResponse<Supplier>
            {
                Message = "Failed."
            };
            try
            {
                response.Data = await _dapperContext.ExecuteProcAsync<Supplier>("Proc_GetSupplier", new
                {
                    loginId,
                    Id,
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("SupplierService", "List", ex.Message);
            }
            return response;
        }
    }
}
