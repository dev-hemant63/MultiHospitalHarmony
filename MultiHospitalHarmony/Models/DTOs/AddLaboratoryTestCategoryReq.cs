using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddLaboratoryTestCategoryReq:CommonRequest
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public string EntryAt { get; set; }
    }
}
