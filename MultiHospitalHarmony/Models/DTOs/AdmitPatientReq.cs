namespace MultiHospitalHarmony.Models.DTOs
{
    public class AdmitPatientReq
    {
        public string PatientUserName { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Tehsil { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string RelationWithPatient { get; set; }
        public string BloodPressure { get; set; }
        public string PulseRate { get; set; }
        public string Wight { get; set; }
        public int WardType { get; set; }
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public int DoctorId { get; set; }
        public string PrescriptionFile { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public int loginId { get; set; }
        public int HospitalId { get; set; }
        public int WID { get; set; }
        public string ReferedType { get; set; }
        public int ReferedBY { get; set; }
        public bool PreferredForAdmit { get; set; }
    }
}
