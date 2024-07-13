namespace MultiHospitalHarmony.Models
{
    public class MedicalHistory
    {
        public int PatientId { get; set; }
        public bool IsFromAdmitted { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string DoctorInfo { get; set; }
        public string PrescriptionFile { get; set; }
        public string Wight { get; set; }
        public string DateOfVisit { get; set; }
    }
}
