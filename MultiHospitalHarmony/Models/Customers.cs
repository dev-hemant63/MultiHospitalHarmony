using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Customers:CommonModel
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int Pincode { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Tahsil { get; set; }
        public string Address { get; set; }
    }
}
