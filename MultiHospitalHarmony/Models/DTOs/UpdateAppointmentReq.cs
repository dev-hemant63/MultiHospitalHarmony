using MultiHospitalHarmony.Enum;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class UpdateAppointmentReq
    {
        public int AppointmentId { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public MasterStatus Status { get; set; }
        public string Remark { get; set; }
    }
}
