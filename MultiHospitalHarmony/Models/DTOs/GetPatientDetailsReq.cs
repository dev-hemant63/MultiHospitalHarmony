namespace MultiHospitalHarmony.Models.DTOs
{
    public class GetPatientDetailsReq
    {
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public string PatientUserName { get; set; }
    }
}
