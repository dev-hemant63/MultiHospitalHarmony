using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class CommissionReq
    {
        public int Id { get; set; }
        public AppRole RoleId { get; set; }
        public decimal Amount { get; set; }
    }
}
