using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Commission:CommonModel
    {
        public AppRole RoleId { get; set; }
        public decimal Amount { get; set; }
        public string EntryAt { get; set; }
    }
}
