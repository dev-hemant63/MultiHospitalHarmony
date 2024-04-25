using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class MedicineUnitReq:CommonRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
