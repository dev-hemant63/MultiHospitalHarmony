namespace MultiHospitalHarmony.Models
{
    public class PatientDetails
    {
		public int Id { get; set; }
		public string FullName { get; set; }
		public string MobileNo { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string StateName { get; set; }
		public string CityName { get; set; }
		public bool IsRelease { get; set; }
		public int ZipCode { get; set; }
		public decimal WardFees { get; set; }
		public DateTime RegistrationDate { get; set; }
		public DateTime DOB { get; set; }
		public int Age { get; set; }
		public string BloodGroup { get; set; }
		public string GuardianName { get; set; }
		public string GuardianMobile { get; set; }
		public string Relation_with_Patient { get; set; }
		public string Marital { get; set; }
		public DateTime AdmissionDate { get; set; }
		public string WardDetailsJson { get; set; }
        public List<WardDetails> WardDetails { get; set; } = new List<WardDetails>();
		public string DoctorVisitJson { get; set; }
		public List<DoctorVisitDetails> DoctorVisit { get; set; } = new List<DoctorVisitDetails>();
		public string MedicalHistoryJson { get; set; }
		public List<MedicalHistoryDetails> MedicalHistory { get; set; } = new List<MedicalHistoryDetails>();
		public string SurgeriesDetailsJson { get; set; }
        public List<SurgeriesDetails> SurgeriesDetails { get; set; } = new List<SurgeriesDetails>();
	}
    public class WardDetails
    {
        public int Id { get; set; }
        public string StartOn { get; set; }
        public string EndOn { get; set; }
        public string WardName { get; set; }
        public decimal Charge { get; set; }
        public string WardType { get; set; }
        public string BedName { get; set; }
    }
    public class DoctorVisitDetails
    {
        public string DoctorInfo { get; set; }
        public string VisitTime { get; set; }
        public string VisitDate { get; set; }
        public string WardVisitFee { get; set; }
    }
    public class MedicalHistoryDetails
    {
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string PrescriptionFile { get; set; }
        public string Wight { get; set; }
        public string DateOfVisit { get; set; }
        public string DoctorInfo { get; set; }
    }
    public class SurgeriesDetails
    {
        public string ScheduledDate { get; set; }
        public bool IsComplete { get; set; }
        public string Remark { get; set; }
        public string SurgeryName { get; set; }
        public decimal Price { get; set; }
        public string DoctorInfo { get; set; }
    }
}
