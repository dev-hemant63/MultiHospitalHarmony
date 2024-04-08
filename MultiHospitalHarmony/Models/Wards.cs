using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
	public class Wards:CommonModel
	{
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public int Capacity_of_bed { get; set; }
        public int CurrentOccupancy { get; set; }
    }
}
