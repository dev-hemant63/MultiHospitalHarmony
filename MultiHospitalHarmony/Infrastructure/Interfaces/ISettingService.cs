using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ISettingService
    {
        Task<AppResponse<List<Module>>> GetModuleList(int loginId);
        Task<AppResponse<object>> SaveModule(int loginId, Module module);
        Task<AppResponse<Module>> GetModuleById(int Id);
        Task<AppResponse<List<MasterPage>>> GetPageList(int moduleId);
    }
}
