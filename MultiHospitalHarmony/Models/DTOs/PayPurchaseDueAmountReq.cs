using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class PayPurchaseDueAmountReq:CommonRequest
    {
        public decimal DueAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int PaymentMode { get; set; }
        public string Remark { get; set; }
    }
}
