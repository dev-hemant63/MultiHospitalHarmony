using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using Newtonsoft.Json;
using ServiceStack;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
	public class CommonService : ICommonService
	{
		private readonly IDapperContext _dapperContext;
		private readonly IApiUtilityService _apiUtilityService;
        public CommonService(IDapperContext dapperContext, IApiUtilityService apiUtilityService)
		{
			_dapperContext = dapperContext;
            _apiUtilityService = apiUtilityService;

        }
		public async Task<AppResponse<List<MasterModule>>> GetModules(int UserId)
		{
			var response = new AppResponse<List<MasterModule>>
			{
				Success = false,
				Message = "An error has occurred; try again later.",
				Data = null
			};

			try
			{
				var result = await _dapperContext.GetAllAsync<MasterModule>("Proc_GetMinus", new { UserId }, CommandType.StoredProcedure);
				response.Success = true;
				response.Message = "Success";
				response.Data = result;
			}
			catch (Exception ex)
			{
				_dapperContext.SaveLog("CommonService", "GetModules", ex.Message);
			}

			return response;
		}

		public async Task<AppResponse<List<MasterMinus>>> GetSubMinus(int UserId)
		{
			var response = new AppResponse<List<MasterMinus>>
			{
				Success = false,
				Message = "An error has been occured try after sometime.",
				Data = null
			};
			try
			{
				var result = await _dapperContext.GetAllAsync<MasterMinus>("Proc_GetSubMinus", new { UserId }, CommandType.StoredProcedure);
				response.Success = true;
				response.Message = "Success";
				response.Data = result;
			}
			catch (Exception ex)
			{
				_dapperContext.SaveLog("CommonService", "GetSubMinus", ex.Message);
			}
			return response;
		}
		public async Task<AppResponse<DetailsByPincode>> GetDetailsByPincode(int pincode)
		{
			var res = new AppResponse<DetailsByPincode>();
			try
			{
				var apiRes = _apiUtilityService.CallApiUsingGet($"https://api.postalpincode.in/pincode/{pincode}");
				if (!string.IsNullOrEmpty(apiRes))
				{
					var pincodeDetails = JsonConvert.DeserializeObject<List<PincodeApiRes>>(apiRes);
					if (pincodeDetails.FirstOrDefault().PostOffice != null)
					{
						var pincodeDetail = pincodeDetails.FirstOrDefault().PostOffice.FirstOrDefault();
						res.Data = await _dapperContext.ExecuteProcAsync<DetailsByPincode>("Proc_GetAreaDetails",new
						{
                            CityName = pincodeDetail.District,
                            StateName = pincodeDetail.State,
                        },CommandType.StoredProcedure);
                        res.Data.Circle = pincodeDetail.Circle;
                        res.Data.State = pincodeDetail.State;
                        res.Data.District = pincodeDetail.District;
                        res.Data.Description = pincodeDetail.Description;
						res.Success = true;
						res.Message = "Success";
                    }
				}
            }
			catch (Exception ex)
			{
                _dapperContext.SaveLog("CommonService", "GetDetailsByPincode", ex.Message);
            }
			return res;
        }
        public async Task<AppResponse<List<City>>> GetCity()
        {
            var res = new AppResponse<List<City>>
			{
				Message = "Failed."
			};
            try
            {
                res.Data = await _dapperContext.GetAllAsync<City>("select * from MasterCity", null, CommandType.Text);
				res.Success = true;
				res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommonService", "GetCity", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<State>>> GetState()
        {
            var res = new AppResponse<List<State>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<State>("select * from MasterState", null, CommandType.Text);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommonService", "GetState", ex.Message);
            }
            return res;
        }
		public async Task<AppResponse<List<ApplicationRole>>> GetUserRole(int loginId)
		{
            var res = new AppResponse<List<ApplicationRole>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<ApplicationRole>("Proc_GetUserRole", new
				{
					loginId
				}, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CommonService", "GetUserRole", ex.Message);
            }
            return res;
        }
    }
}
