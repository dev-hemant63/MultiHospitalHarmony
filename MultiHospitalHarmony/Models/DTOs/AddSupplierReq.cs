using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddSupplierReq:CommonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Pincode { get; set; }
        public string Tahsil { get; set; }
        public string Address { get; set; }
    }
}
