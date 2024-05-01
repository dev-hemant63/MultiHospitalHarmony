using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class InvoiceItem:CommonModel
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string ExpiryDate { get; set; }
        public decimal TotalQty { get; set; }
        public decimal BoxQty { get; set; }
        public decimal Price { get; set; }
    }
}
