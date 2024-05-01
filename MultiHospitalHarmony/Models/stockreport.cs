using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class stockreport:CommonModel
    {
        public string Supplier { get; set; }
        public string Medicine { get; set; }
        public string BatchCode { get; set; }
        public string ExpiryDate { get; set; }
        public string BoxSize { get; set; }
        public decimal BalQty { get; set; }
        public decimal Qty { get; set; }
        public decimal BoxQty { get; set; }
        public decimal ClosingQty { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal MRP { get; set; }
        public bool IsOut { get; set; }
    }
}
