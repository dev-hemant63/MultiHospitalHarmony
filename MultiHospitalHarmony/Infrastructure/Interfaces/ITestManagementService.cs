using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ITestManagementService
    {
        Task<AppResponse<object>> SaveLaboratoryTestCategory(int loginId, AddLaboratoryTestCategoryReq addLaboratory);
        Task<AppResponse<List<AddLaboratoryTestCategoryReq>>> GetLaboratoryTestCategory(int loginId, GetLaboratoryTestCategoryReq testCategoryReq);
        Task<AppResponse<object>> SaveLaboratoryTest(int loginId, LaboratoryTestReq laboratoryTestReq);
        Task<AppResponse<List<LaboratoryTestReq>>> GetLaboratoryTest(int loginId, GetLaboratoryTestCategoryReq testCategoryReq);
    }
}
