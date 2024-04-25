using MultiHospitalHarmony.Enum;

namespace MultiHospitalHarmony.Models.Common
{
    public class CommonFilter:CommonRequest
    {
        public AppRole RoleId { get; set; }
        public string SearchText { get; set; }
        public SearchCriteria SearchCriteria { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
