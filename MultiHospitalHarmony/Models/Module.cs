using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Module:CommonModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public string EntryAt { get; set; }
    }
}
