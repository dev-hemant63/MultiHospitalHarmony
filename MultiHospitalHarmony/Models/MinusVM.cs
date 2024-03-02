using MultiHospitalHarmony.Enum;

namespace MultiHospitalHarmony.Models
{
	public class MinusVM
	{
        public List<MasterModule> MasterModule { get; set; }
        public List<MasterMinus> MasterMinus { get; set; }
        public AppRole Role { get; set; }
    }
}
