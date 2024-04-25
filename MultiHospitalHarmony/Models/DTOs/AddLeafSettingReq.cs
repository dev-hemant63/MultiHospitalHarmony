using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddLeafSettingReq:CommonRequest
    {
        public string LeafType { get; set; }
        public int TotalNumber { get; set; }
    }
}
