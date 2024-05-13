using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class GetLabInvoiceDetails:CommonModel
    {
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public int Status { get; set; }
        public string Laboratory_Invoice_DetailsJson { get; set; }
        public string InvoiceFrom_Json { get; set; }
        public string InvoiceTo_Json { get; set; }
        public List<Laboratory_Invoice_Detail> Laboratory_Invoice_Details { get; set; }
        public InvoiceFrom InvoiceFrom { get; set; }
        public InvoiceFrom InvoiceTo { get; set; }
    }
    public class Laboratory_Invoice_Detail
    {
        public string TestCategory { get; set; }
        public string LaboratoryTest { get; set; }
        public decimal UnitCost { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
    }
}
