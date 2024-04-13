namespace MultiHospitalHarmony.Models.DTOs
{
    public class GetWardTypeReq
    {
        public int Id { get; set; }
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int WardTypeId { get; set; }
    }
}
