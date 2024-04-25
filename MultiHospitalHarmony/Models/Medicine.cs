using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Medicine:CommonModel
    {
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int MedicineType { get; set; }
        public int BoxSize { get; set; }
        public int UnitId { get; set; }
        public string BarCode { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Supplier { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
        public string Unit { get; set; }
        public string BoxSiz { get; set; }
        public string Shelf { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal Tax { get; set; }
        public string Image { get; set; }
    }
}
