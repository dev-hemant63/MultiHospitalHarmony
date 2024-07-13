using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class OperationTheatreService : IOperationTheatreService
    {
        private readonly IDapperContext _dapperContext;
        public OperationTheatreService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> SaveSurgeries(int loginId, SaveSurgeriesReq surgeriesReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveSurgeries", new
                {
                    loginId,
                    surgeriesReq.Id,
                    surgeriesReq.WID,
                    surgeriesReq.HospitalId,
                    surgeriesReq.SurgeryName,
                    surgeriesReq.Description
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("OperationTheatreService", "SaveSurgeries", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<SaveSurgeriesReq>>> GetSurgeries(int loginId, GetSurgeriesReq surgeriesReq)
        {
            var res = new AppResponse<List<SaveSurgeriesReq>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<SaveSurgeriesReq>("Proc_GetSurgeries", new
                {
                    loginId,
                    surgeriesReq.Id,
                    surgeriesReq.WID,
                    surgeriesReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("OperationTheatreService", "GetSurgeries", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<SaveSurgeriesReq>> GetSurgeriesById(int loginId, GetSurgeriesReq surgeriesReq)
        {
            var res = new AppResponse<SaveSurgeriesReq>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<SaveSurgeriesReq>("Proc_GetSurgeries", new
                {
                    loginId,
                    surgeriesReq.Id,
                    surgeriesReq.WID,
                    surgeriesReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("OperationTheatreService", "GetSurgeriesById", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> DoctorSurgerieMaping(int loginId, DoctorSurgerieMapingReq mapingReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_DoctorSurgerieMaping", new
                {
                    loginId,
                    mapingReq.Id,
                    mapingReq.WID,
                    mapingReq.HospitalId,
                    mapingReq.DoctorId,
                    mapingReq.SurgerieId,
                    mapingReq.Price
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("OperationTheatreService", "DoctorSurgerieMaping", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<GetDoctorAndSurgery>>> GetDoctorAndSurgery(int loginId, GetSurgeriesReq surgeriesReq)
        {
            var res = new AppResponse<List<GetDoctorAndSurgery>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<GetDoctorAndSurgery>("Proc_GetDoctorAndSurgery", new
                {
                    loginId,
                    surgeriesReq.Id,
                    surgeriesReq.WID,
                    surgeriesReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("OperationTheatreService", "GetDoctorAndSurgery", ex.Message);
            }
            return res;
        }
    }
}
