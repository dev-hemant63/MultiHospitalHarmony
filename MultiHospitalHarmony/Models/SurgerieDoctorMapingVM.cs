using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Models
{
    public class SurgerieDoctorMapingVM
    {
        public List<SaveSurgeriesReq> Surgeries { get; set; }
        public List<Users> Doctors { get; set; }
        public List<GetDoctorAndSurgery> DoctorAndSurgery { get; set; }
    }
}
