using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
	public class WardType:CommonModel
	{
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
