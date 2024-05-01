using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class InvoiceDetails : CommonModel
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Details { get; set; }
        public decimal GST { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal SubTotalAmount { get; set; }
        public int Status { get; set; }
        public InvoiceFrom PharmacyDetails { get; set; }
        public string PharmacyDetailsJson { get; set; }
        public InvoiceTo CustomerDetail { get; set; }
        public string CustomerDetailJson { get; set; }
        public string InvoiceDetailsJson { get; set; }
        public List<InvoiceItems> InvoiceDetail { get; set; }
    }
    public class InvoiceFrom
    {
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Tehsil { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    public class InvoiceTo
    {
        public string Name { get; set;}
        public string MobileNo { get; set;}
        public string EmailId { get; set;}
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string Tahsil { get; set; }
    }
    public class InvoiceItems
    {
        public string Medicine { get; set;}
        public string UnitName { get; set;}
        public string BatchCode { get; set;}
        public string ExpiryDate { get; set;}
        public decimal Quantity { get; set;}
        public decimal PricePerUnit { get; set;}
    }
}
