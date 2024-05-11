using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class Laboratory_InvoiceReq:CommonRequest
    {
        public int PatientId { get; set; }
        public string InvoiceDate { get; set; }
        public string Details { get; set; }
        public int PaymentModeId { get; set; }
        public string Remark { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public List<Laboratory_Invoice_Details> Laboratory_Invoice_Details { get; set; }
    }
    public class Laboratory_Invoice_Details
    {
        public int TestCategoryId { get; set; }
        public int TestId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
    }
}
