using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddInvoiceReq:CommonRequest
    {
        public int CustomerId { get; set; }
        public string InvoiceDate { get; set; }
        public string Details { get; set; }
        public int PaymentModeId { get; set; }
        public string Remark { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal SubTotalAmount { get; set; }
        public List<InvoicesItems> InvoicesItems { get; set; }
    }
    public class InvoicesItems
    {
        public int MedicineId { get; set; }
        public string BatchCode { get; set; }
        public string ExpiryDate { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}
