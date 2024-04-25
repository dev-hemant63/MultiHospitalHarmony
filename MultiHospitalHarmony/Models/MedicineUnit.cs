using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class MedicineUnit:CommonModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
