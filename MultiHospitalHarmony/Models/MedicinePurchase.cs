using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class MedicinePurchase:CommonModel
    {
        public string Supplier { get; set; }
        public string InvoiceNo { get; set; }
        public int Status { get; set; }
        public string PurchaseDate { get; set; }
        public string Details { get; set; }
        public string Remark { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
