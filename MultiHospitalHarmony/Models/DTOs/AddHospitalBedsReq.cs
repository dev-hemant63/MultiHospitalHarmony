namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddHospitalBedsReq
    {
        public int Id { get; set; }
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int WardId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
