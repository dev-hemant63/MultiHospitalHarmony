using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class ReportService: IReportService
    {
        private readonly IDapperContext _dapperContext;
        public ReportService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<List<stockreport>>> Getstockreport(int loginId,GetstockreportReq getstockreportReq)
        {
            var res = new AppResponse<List<stockreport>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<stockreport>("Proc_Getstockreport", new
                {
                    loginId,
                    getstockreportReq.WID,
                    getstockreportReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("ReportService", "Getstockreport", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<stockreport>>> GetStockReportBatchWise(int loginId, GetstockreportReq getstockreportReq)
        {
            var res = new AppResponse<List<stockreport>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<stockreport>("Proc_GetStockReportBatchWise", new
                {
                    loginId,
                    getstockreportReq.WID,
                    getstockreportReq.HospitalId,
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("ReportService", "Getstockreport", ex.Message);
            }
            return res;
        }
    }
}
