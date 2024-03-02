using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ISMSService
    {
        Task<AppResponse<object>> Send();
    }
}
