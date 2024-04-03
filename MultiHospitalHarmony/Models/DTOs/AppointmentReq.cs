using MultiHospitalHarmony.Enum;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AppointmentReq
    {
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string PatientMobileNo { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Time { get; set; }
        public MasterStatus Status { get; set; }
        public string AppointmentDate { get; set; }
    }
}
