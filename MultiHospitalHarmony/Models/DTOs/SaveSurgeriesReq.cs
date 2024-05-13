using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class SaveSurgeriesReq:CommonRequest
    {
        public string SurgeryName { get; set; }
        public string Description { get; set; }
        public string EntryAt { get; set; }
    }
}
