using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Appointments:CommonModel
    {
        public string Doctor { get; set; }
        public string PatientName { get; set; }
        public string PatientMobileNo { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Time { get; set; }
        public MasterStatus Status { get; set; }
        public string AppointmentDate { get; set; }
        public string Remark { get; set; }
    }
}
