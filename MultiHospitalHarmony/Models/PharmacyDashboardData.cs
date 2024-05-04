namespace MultiHospitalHarmony.Models
{
    public class PharmacyDashboardData
    {
        public int TotalCustomer { get; set; }
        public int TotalMedicine { get; set; }
        public int OutOfStock { get; set; }
        public int ExpiredMedicine { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalPurchase { get; set; }
        public decimal CashReceived { get; set; }
        public decimal BankReceive { get; set; }
        public string SaleInfoJson { get; set; }
        public List<SaleInfo> SaleInfo { get; set; } = new List<SaleInfo>();
    }
    public class SaleInfo
    {
        public string CustomerInfo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string EntryAt { get; set; }
    }
}
