using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class MasterPage:CommonModel
    {
        public int ModuleId { get; set; }
        public string PageName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
        public string EntryAt { get; set; }
    }
}
