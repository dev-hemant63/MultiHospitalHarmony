namespace MultiHospitalHarmony.Models.DTOs
{
    public class PatientReleaseReq
    {
        public List<PatientBillingServices> Services { get; set; }
        public int WID { get; set; }
        public int HospitalId { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public string InvoiceNo { get; set; }
        public int BankId { get; set; }
        public int PaymentModeId { get; set; }
    }
}
