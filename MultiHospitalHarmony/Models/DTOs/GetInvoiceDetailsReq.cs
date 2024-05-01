using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class GetInvoiceDetailsReq:CommonRequest
    {
        public int InvoiceId { get; set; }
    }
}
