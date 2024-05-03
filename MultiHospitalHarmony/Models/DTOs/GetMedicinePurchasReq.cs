using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class GetMedicinePurchasReq:CommonRequest
    {
        public int PurchaseId { get; set; }
        public int StatusId { get; set; }
    }
}
