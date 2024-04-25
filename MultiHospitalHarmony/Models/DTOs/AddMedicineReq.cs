using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class AddMedicineReq:CommonRequest
    {
        public string BarCode { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int MedicineType { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
        public int BoxSize { get; set; }
        public int UnitId { get; set; }
        public string Shelf { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal TaxInPercentage { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
