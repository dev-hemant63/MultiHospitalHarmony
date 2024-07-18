namespace MultiHospitalHarmony.Models
{
    public class AdmitedPatientBillList
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AdmissionDate { get; set; }
        public string DispatchDate { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal PayableAmount { get; set; }
        public string PaymentMode { get; set; }
    }
}
