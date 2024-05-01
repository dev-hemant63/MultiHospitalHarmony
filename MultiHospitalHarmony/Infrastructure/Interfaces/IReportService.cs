using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IReportService
    {
        Task<AppResponse<List<stockreport>>> Getstockreport(int loginId, GetstockreportReq getstockreportReq);
        Task<AppResponse<List<stockreport>>> GetStockReportBatchWise(int loginId, GetstockreportReq getstockreportReq);
    }
}
