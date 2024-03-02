using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IAlertService
    {
        Task<AppResponse<object>> Send();
    }
}
