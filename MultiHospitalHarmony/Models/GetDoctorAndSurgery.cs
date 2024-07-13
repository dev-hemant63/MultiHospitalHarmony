using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class GetDoctorAndSurgery:CommonModel
    {
        public int SurgerieId { get; set; }
        public int DoctorId { get; set; }
        public string SurgeryName { get; set; }
        public string DoctorName { get; set; }
        public string Price { get; set; }
    }
}
