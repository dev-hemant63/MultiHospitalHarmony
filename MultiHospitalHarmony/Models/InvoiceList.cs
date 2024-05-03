using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class InvoiceList:CommonModel
    {
        public string CustomerInfo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
        public decimal GST { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
