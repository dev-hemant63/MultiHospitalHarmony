using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class DoctorSurgerieMapingReq:CommonModel
    {
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public int SurgerieId { get; set; }
        public decimal Price { get; set; }
    }
}
