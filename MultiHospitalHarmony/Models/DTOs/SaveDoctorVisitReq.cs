using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class SaveDoctorVisitReq
    {
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public string VisitTime { get; set; }
        public string VisitDate { get; set; }
        public int PatientId { get; set; }
    }
}
