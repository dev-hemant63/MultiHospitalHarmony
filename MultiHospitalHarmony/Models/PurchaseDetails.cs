namespace MultiHospitalHarmony.Models
{
    public class PurchaseDetails
    {
        public string InvoiceNo { get; set; }
        public string PurchaseDate { get; set; }
        public string Supplier { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string CityName { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public int Status { get; set; }
        public string PurchaseMedicineDetailsJson { get; set; }
        public List<PurchaseMedicineDetails> PurchaseMedicineDetails { get; set; }
        public string PaymentDetailsJson { get; set; }
        public List<PaymentDetails> PaymentDetails { get; set; }
    }
    public class PurchaseMedicineDetails
    {
        public string Medicine { get; set; }
        public string BatchCode { get; set; }
        public string ExpiryDate { get; set; }
        public string BoxSize { get; set; }
        public decimal BoxQty { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal MRP { get; set; }
        public decimal TotalPurchasePrice { get; set; }
    }
    public class PaymentDetails
    {
        public string Mode { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Remark { get; set; }
        public string EntryAt { get; set; }
    }
}
