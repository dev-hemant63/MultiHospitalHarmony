using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AppointmentsFilter: CommonFilter
    {
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
    }
}
