namespace MultiHospitalHarmony.Models
{
    public class MedicinePurchaseDetails
    {
        public int MedicineId { get; set; }
        public string BatchCode { get; set; }
        public string ExpiryDate { get; set; }
        public decimal StockQty { get; set; }
        public int BoxPattern { get; set; }
        public decimal BoxQty { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal MRP { get; set; }
        public decimal TotalPurchasePrice { get; set; }
    }
}
