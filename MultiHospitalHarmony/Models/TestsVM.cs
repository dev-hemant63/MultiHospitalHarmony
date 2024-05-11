using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Models
{
    public class TestsVM
    {
        public AppResponse<List<AddLaboratoryTestCategoryReq>> TestCategory { get; set; }
        public AppResponse<List<LaboratoryTestReq>> LaboratoryTest { get; set; }
    }
}
