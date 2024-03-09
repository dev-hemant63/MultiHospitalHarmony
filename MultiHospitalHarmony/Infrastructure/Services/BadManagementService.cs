using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

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
    }
}
