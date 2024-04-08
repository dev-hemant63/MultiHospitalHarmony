using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class WardService: IWardService
    {
        private readonly IDapperContext _dapperContext;
        public WardService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Add(int loginId,AddWardReq addWardReq)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveWard", new
                {
					addWardReq.Id,
					addWardReq.HospitalId,
					addWardReq.WID,
					addWardReq.Name,
					addWardReq.Type,
					addWardReq.Capacity_of_bed,
					LoginId = loginId
				});
			}
            catch (Exception ex)
            {
				_dapperContext.SaveLog("WardService", "Add", ex.Message);
			}
            return response;
		}
        public async Task<AppResponse<object>> AddWardType(int loginId, AddWardTypeReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveWardType", new
                {
					request.Id,
					request.HospitalId,
					request.WID,
					request.Name,
					request.Remark,
					LoginId = loginId
				});
			}
            catch (Exception ex)
            {
				_dapperContext.SaveLog("WardService", "AddWardType", ex.Message);
			}
            return response;
		}
        public async Task<AppResponse<List<WardType>>> GetWardType(int loginId, GetWardTypeReq request)
        {
            var response = new AppResponse<List<WardType>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<WardType>("Proc_GetWardType", new
                {
                    request.HospitalId,
                    request.WID,
                    request.Id
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("WardService", "GetWardType", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<WardType>> GetWardTypeById(int loginId, GetWardTypeReq request)
        {
            var response = new AppResponse<WardType>();
            try
            {
                response.Data = await _dapperContext.ExecuteProcAsync<WardType>("Proc_GetWardType", new
                {
                    request.HospitalId,
                    request.WID,
                    request.Id
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("WardService", "GetWardTypeById", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Wards>>> GetWardList(int loginId, GetWardTypeReq request)
        {
            var response = new AppResponse<List<Wards>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Wards>("Proc_GetWardList", new
                {
                    request.HospitalId,
                    request.WID,
                    request.Id
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("WardService", "GetWardList", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<Wards>> GetWardById(int loginId, GetWardTypeReq request)
        {
            var response = new AppResponse<Wards>();
            try
            {
                response.Data = await _dapperContext.ExecuteProcAsync<Wards>("Proc_GetWardList", new
                {
                    request.HospitalId,
                    request.WID,
                    request.Id
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("WardService", "GetWardList", ex.Message);
            }
            return response;
        }
    }
}
