using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Laboratory_Invoice:CommonModel
    {
        public string PatientInfo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Details { get; set; }
        public string PaymentMode { get; set; }
        public string Remark { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public int Status { get; set; }
    }
}
