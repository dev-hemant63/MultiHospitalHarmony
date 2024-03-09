namespace MultiHospitalHarmony.Models
{
    public class PatientDeatilsVM
    {
        public Users BasicDetails { get; set; }
        public List<MedicalHistory> MedicalHistory { get; set; }
    }
}
