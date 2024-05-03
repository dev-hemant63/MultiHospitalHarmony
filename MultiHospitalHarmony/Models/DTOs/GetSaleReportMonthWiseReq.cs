using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class GetSaleReportMonthWiseReq:CommonRequest
    {
        public int Year { get; set; }
    }
}
