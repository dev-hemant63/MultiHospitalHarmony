using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        Task<AppResponse<object>> Add(int loginId, AddInvoiceReq addInvoiceReq);
        Task<AppResponse<List<InvoiceItem>>> GetInvoiceItem(int loginId, GetInvoiceItemReq getInvoiceItemReq);
        Task<AppResponse<List<InvoiceList>>> GetInvoiceList(int loginId, GetInvoiceListReq getInvoiceListReq);
        Task<AppResponse<InvoiceDetails>> GetInvoiceDetail(int loginId, GetInvoiceDetailsReq getInvoiceDetailsReq);
        Task<AppResponse<object>> CancelReturnSale(int loginId, ReturnSaleReq request);
        Task<AppResponse<List<SaleReportMonthWise>>> GetSaleReportMonthWise(int loginId, GetSaleReportMonthWiseReq reportMonthWiseReq);
        Task<AppResponse<List<SaleReportMonthWise>>> GetPurchaseReportMonthWise(int loginId, GetSaleReportMonthWiseReq reportMonthWiseReq);
        Task<AppResponse<object>> AddLaboratory_Invoice(int loginId, Laboratory_InvoiceReq request);
        Task<AppResponse<List<Laboratory_Invoice>>> GetLaboratory_InvoiceList(int loginId, GetLaboratory_InvoiceReq getLaboratory);
        Task<AppResponse<GetLabInvoiceDetails>> GetLabInvoiceDetails(int loginId, GetLaboratory_InvoiceReq getLaboratory);
        Task<AppResponse<List<SaleReportMonthWise>>> GetLabSaleReportMonthWise(int loginId, GetSaleReportMonthWiseReq reportMonthWiseReq);
        Task<AppResponse<List<AdmitedPatientBillList>>> GetAdmitedPatientBillList(int loginId, GetAdmitedPatientBillListReq patientBillListReq);

    }
}
