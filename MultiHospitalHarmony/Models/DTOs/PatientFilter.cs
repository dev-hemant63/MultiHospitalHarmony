using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class PatientFilter:CommonFilter
    {
        public int WID { get; set; }
        public int HospitalId { get; set; }
    }
}
