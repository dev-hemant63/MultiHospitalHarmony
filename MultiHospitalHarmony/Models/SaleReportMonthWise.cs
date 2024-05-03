namespace MultiHospitalHarmony.Models
{
    public class SaleReportMonthWise
    {
        public string MonthName { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal GST { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
