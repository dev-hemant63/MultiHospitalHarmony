using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class HospitalBeds: CommonModel
    {
        public int HospitalId { get; set; }
        public int WID { get; set; }
        public int WardId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
