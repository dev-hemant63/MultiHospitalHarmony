namespace MultiHospitalHarmony.Models
{
    public class AdmitedPatientList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string BloodGroup { get; set; }
        public int Age { get; set; }
        public string ReferedType { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string Relation_with_Patient { get; set; }
        public string Marital { get; set; }
        public string AdmissionDate { get; set; }
        public string DispatchDate { get; set; }
        public string PulseRate { get; set; }
        public string Tehsil { get; set; }
    }
}
