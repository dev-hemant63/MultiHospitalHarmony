using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class BadsReq:CommonModel
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Price { get; set; }
    }
}
