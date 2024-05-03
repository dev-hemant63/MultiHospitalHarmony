using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class CancelReturnPurchaseReq:CommonRequest
    {
        public int StatusId { get; set; }
    }
}
